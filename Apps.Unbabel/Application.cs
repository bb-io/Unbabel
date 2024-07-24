using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Unbabel;

public class Application : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.MachineTranslationAndMtqe];
        set { }
    }

    public string Name
    {
        get => "Unbabel";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}