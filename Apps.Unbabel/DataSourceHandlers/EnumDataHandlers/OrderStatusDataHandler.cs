using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.DataSourceHandlers.EnumDataHandlers;

public class OrderStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "created", "Created" },
        { "services_pre_pipeline", "Services pre pipeline" },
        { "services_post_pipeline", "Services post pipeline" },
        { "in_progress", "In progress" },
        { "completed", "Completed" },
        { "failed", "Failed" },
    };
}