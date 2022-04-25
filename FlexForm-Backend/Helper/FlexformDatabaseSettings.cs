using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace FlexForm_Backend.Helper;

public interface IFlexformDatabaseSettings
{
    string FlexformCollectionName { get; set; } 
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}

public class FlexformDatabaseSettings : IFlexformDatabaseSettings
{
    public string FlexformCollectionName { get; set; } = String.Empty;
    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}
