using Apps.Unbabel.Constants;
using Apps.Unbabel.Extensions;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.File;
using Apps.Unbabel.Models.Request.Project;
using Apps.Unbabel.Models.Response.File;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;
using Blackbird.Applications.Sdk.Common.Files;
using System.Net.Mime;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace Apps.Unbabel.Actions;

[ActionList]
public class FileActions : UnbabelInvocable
{
    private readonly IFileManagementClient _fileManagementClient;
    public FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("(P) Upload file", Description = "Upload a new file to the project")]
    public async Task<FileEntity> UploadFile(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] UploadFileInput input,
        [ActionParameter] FileContentRequest file)
    {
        var request = new RestRequest($"/v0/customers/{CustomerId}/projects/{project.ProjectId}/files",
                Method.Post)
            .WithJsonBody(new UploadFileRequest(input, file), JsonConfig.Settings);
        var response = await ProjectsClient.ExecuteWithErrorHandling<UploadFileResponse>(request, Creds);

        var fileBytes = _fileManagementClient.DownloadAsync(file.File).Result.GetByteData().Result;
        var uploadRequest = new RestRequest(response.UploadUrl, Method.Put)
            .AddFile("file", fileBytes, file.File.Name);
        var uploadResponse = await new RestClient().ExecuteAsync(uploadRequest);

        if (!uploadResponse.IsSuccessStatusCode)
            throw new(uploadResponse.Content);

        return response;
    }

    [Action("(P) Download file", Description = "Download content of a source or delivered file in a project")]
    public async Task<FileResponse> DownloadFile([ActionParameter] FileRequest input)
    {
        var endpoint = $"/v0/customers/{CustomerId}/projects/{input.ProjectId}/files/{input.FileId}";
        var request = new RestRequest(endpoint);

        var file = await ProjectsClient.ExecuteWithErrorHandling<FileEntity>(request, Creds);

        var downloadResponse = await DownloadFileContent(file.DownloadUrl);

        var bytes = downloadResponse.RawBytes;

        // Yes apparently this is necessary since Unbabel will return an additional boundary as if it were multipart/form-data if the content is plaintext.
        if (downloadResponse.Content.StartsWith("--") &&
            downloadResponse.Content.EndsWith("--") &&
            downloadResponse.Content.Contains("application/octet-stream content-disposition"))
        {
            var cleanedContent = downloadResponse.Content.Remove(downloadResponse.Content.Length - 40).Split('»')[2];
            bytes = Encoding.UTF8.GetBytes(cleanedContent);
        }

        using var stream = new MemoryStream(bytes);
        var fileResult = await _fileManagementClient.UploadAsync(stream, MimeTypes.GetMimeType(file.Name), file.Name);

        return new(fileResult);
    }

    private async Task<RestResponse> DownloadFileContent(string fileDownloadUrl)
    {
        var response = await new RestClient().ExecuteAsync(new(fileDownloadUrl));

        if (!response.IsSuccessStatusCode)
            throw new($"Failed to download file from {fileDownloadUrl}; Response: {response.Content}");

        return response;
    }
}