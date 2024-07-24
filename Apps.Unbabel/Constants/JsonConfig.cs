using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Apps.Unbabel.Constants;

public static class JsonConfig
{
    public static JsonSerializerSettings Settings => new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        },
        NullValueHandling = NullValueHandling.Ignore
    };
}