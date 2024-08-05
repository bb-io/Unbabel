using Apps.Unbabel.Api;
using Apps.Unbabel.Constants;
using Apps.Unbabel.Enums;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;

namespace Apps.Unbabel.Invocables;

public class UnbabelInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected UnbabelClient TranslationsClient { get; }
    protected UnbabelClient ProjectsClient { get; }
    protected UnbabelClient PipelinesClient { get; }
    protected UnbabelClient QiClient { get; }

    protected string CustomerId { get; }

    public UnbabelInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        TranslationsClient = new(ApiType.Translations);
        ProjectsClient = new(ApiType.Projects);
        PipelinesClient = new(ApiType.Pipelines);
        QiClient = new(ApiType.Qi);
        CustomerId = Creds.Get(CredsNames.CustomerId).Value;
    }
}