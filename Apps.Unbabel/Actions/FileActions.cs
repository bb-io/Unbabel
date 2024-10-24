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

        if (file.DownloadUrl is null)
            throw new("File does not have content yet");

        var reference = new FileReference(new HttpRequestMessage(HttpMethod.Get, new Uri(file.DownloadUrl)), file.Name, MimeTypes.GetMimeType(file.Name));

        return new(reference);
    }
}