using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.DataSourceHandlers.StaticHandlers;

public class ErrorSpanPrecisionLevelStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["precise"] = "Precise",
            ["balanced"] = "Balanced",
            ["sensitive"] = "Sensitive",
        };
    }
}