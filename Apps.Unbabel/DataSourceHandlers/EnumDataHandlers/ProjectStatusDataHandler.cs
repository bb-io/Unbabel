using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Unbabel.DataSourceHandlers.EnumDataHandlers;

public class ProjectStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData() => new()
    {
        { "created", "Created" },
        { "submitted", "Submitted" },
        { "estimating", "Estimating" },
        { "estimated", "Estimated" },
        { "estimate_expired", "Estimate expired" },
        { "in_progress", "In progress" },
        { "delivered", "Delivered" },
        { "canceled", "Canceled" },
        { "failed", "Failed" }
    };
}