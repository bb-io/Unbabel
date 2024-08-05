using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.DataSourceHandlers.StaticHandlers;

public class ScoreComputationMethodStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["from_annotation_severities"] = "From annotation severities",
            ["from_annotation_severities_adjusted"] = "From annotation severities adjusted",
        };
    }
}