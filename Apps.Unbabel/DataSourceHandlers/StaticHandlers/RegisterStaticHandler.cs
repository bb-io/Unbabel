using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.DataSourceHandlers.StaticHandlers;

public class RegisterStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["formal"] = "Formal",
            ["informal"] = "Informal",
        };
    }
}