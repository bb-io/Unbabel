namespace Apps.Unbabel.Constants;

public static class Urls
{
    private const string Api = "https://api.unbabel.com";
    public const string TranslationApi = Api + "/translation";
    public const string PipelinesApi = Api + "/pipelines";
    public const string ProjectsApi = Api + "/projects";
    public const string QiApi = Api + "/qi";

    public const string Token = "https://iam.unbabel.com/auth/realms/production/protocol/openid-connect/token";
}