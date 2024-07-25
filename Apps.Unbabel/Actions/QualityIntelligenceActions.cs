using Apps.Unbabel.Constants;
using Apps.Unbabel.Extensions;
using Apps.Unbabel.Invocables;
using Apps.Unbabel.Models;
using Apps.Unbabel.Models.Request.QualityIntelligence;
using Apps.Unbabel.Models.Response.QualityIntelligence;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Unbabel.Actions;

[ActionList]
public class QualityIntelligenceActions : UnbabelInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public QualityIntelligenceActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) :
        base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Evaluate XLIFF",
        Description =
            "Get a report with quality evaluations at the word, sentence, and document level of the XLIFF file")]
    public async Task<EvaluationResponse> EvaluateXliff(
        [ActionParameter] EvaluationInput input, [ActionParameter] FileModel file)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(file.File);
        var segments = fileStream.GetSegments();

        var request = new RestRequest($"/v1/customers/{CustomerId}/evaluations", Method.Post)
            .WithJsonBody(new EvaluateTranslationRequest(input, segments), JsonConfig.Settings);

        return await QiClient.ExecuteWithErrorHandling<EvaluationResponse>(request, Creds);
    }

    [Action("Explain XLIFF",
        Description = "Get automatic evaluation of a translation accompanied by an explanation of the XLIFF file")]
    public async Task<ExplanationResponse> ExplainXliff(
        [ActionParameter] ExplanationInput input, [ActionParameter] FileModel file)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(file.File);
        var segments = fileStream.GetSegments();

        var request = new RestRequest($"/v1/customers/{CustomerId}/explanations", Method.Post)
            .WithJsonBody(new ExplainTranslationRequest(input, segments), JsonConfig.Settings);

        return await QiClient.ExecuteWithErrorHandling<ExplanationResponse>(request, Creds);
    }
}