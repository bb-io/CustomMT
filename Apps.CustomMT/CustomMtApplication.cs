using Blackbird.Applications.Sdk.Common;

namespace Apps.CustomMT;

public class CustomMtApplication : IApplication
{
    public string Name
    {
        get => "Custom MT";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}