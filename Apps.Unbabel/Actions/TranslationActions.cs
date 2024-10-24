using Apps.Unbabel.Constants;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models.Entities;
using Apps.Unbabel.Models.Request.Translation;
using Apps.Unbabel.Models.Response.Translation;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;
using System.IO;

namespace Apps.Unbabel.Actions;

[ActionList]
public class TranslationActions : UnbabelInvocable
{
    private readonly IFileManagementClient _fileManagementClient;
    public TranslationActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("(T) Translate text", Description = "Translates text using a specified pipeline")]
    public Task<TranslationEntity> SubmitTextTranslation([ActionParameter] SubmitTextTranslationInput input)
        => SubmitTranslation(new(input));

    [Action("(T) Translate file", Description = "Translates a file using a specified pipeline, only txt, html and xliff supported.")]
    public async Task<FileTranslationEntity> SubmitFileTranslation([ActionParameter] SubmitFileTranslationInput input)
    {
        var translation = await SubmitTranslation(new(input, _fileManagementClient));

        using (var stream = new MemoryStream())
        {
            var writer = new StreamWriter(stream);
            writer.Write(translation.TargetText);
            writer.Flush();
            stream.Position = 0;

            var uploadedFile = await _fileManagementClient.UploadAsync(stream, input.File.ContentType, input.File.Name);

            return new FileTranslationEntity
            {
                TargetLanguage = translation.TargetLanguage,
                SourceLanguage = translation.SourceLanguage,
                TextFormat = translation.TextFormat,
                Status = translation.Status,
                PipelineId = translation.PipelineId,
                TranslationUid = translation.TranslationUid,
                TranslatedFile = uploadedFile,
            };
        }   
    }

    private async Task<TranslationEntity> SubmitTranslation(SubmitTranslationRequest payload)
    {
        var endpoint = $"/v1/customers/{CustomerId}/translations:submit_async";
        var request = new RestRequest(endpoint, Method.Post).WithJsonBody(payload, JsonConfig.Settings);

        var submitTranslationResponse =
            await TranslationsClient.ExecuteWithErrorHandling<SubmitTranslationResponse>(request, Creds);

        TranslationEntity? result = default;

        while (result is null || result.Status == "in_progress")
        {            
            result = await GetTranslation(new()
            {
                TranslationId = submitTranslationResponse.TranslationUid
            });
            await Task.Delay(3000);
        }

        return result!;
    }

    private Task<TranslationEntity> GetTranslation([ActionParameter] TranslationRequest input)
    {
        var endpoint = $"/v1/customers/{CustomerId}/translations/{input.TranslationId}";
        var request = new RestRequest(endpoint);

        return TranslationsClient.ExecuteWithErrorHandling<TranslationEntity>(request, Creds);
    }
}