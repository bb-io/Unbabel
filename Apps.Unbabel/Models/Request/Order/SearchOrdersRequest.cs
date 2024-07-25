using Apps.Unbabel.DataSourceHandlers;
using Apps.Unbabel.DataSourceHandlers.StaticHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Unbabel.Models.Request.Order;

public class SearchOrdersRequest
{
    public string? Name { get; set; }
    
    [Display("Pipelines")]
    [DataSource(typeof(PipelineDataHandler))]
    public IEnumerable<string>? PipelineIds { get; set; }
    
    public IEnumerable<string>? Extension { get; set; }
    
    [StaticDataSource(typeof(OrderStatusDataHandler))]
    public IEnumerable<string>? Status { get; set; }
}