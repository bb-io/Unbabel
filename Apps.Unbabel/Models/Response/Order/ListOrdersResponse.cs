using Apps.Unbabel.Models.Entities;

namespace Apps.Unbabel.Models.Response.Order;

public record ListOrdersResponse(List<OrderEntity> Orders);