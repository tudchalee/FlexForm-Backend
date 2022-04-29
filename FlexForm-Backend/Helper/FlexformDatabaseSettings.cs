using HostingEnvironmentExtensions = Microsoft.AspNetCore.Hosting.HostingEnvironmentExtensions;

namespace FlexForm_Backend.Helper;

public interface IFlexformDatabaseSettings
{
    List<string> FlexformCollectionName { get; set; } 
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}

public class FlexformDatabaseSettings : IFlexformDatabaseSettings
{
    public List<string> FlexformCollectionName { get; set; } 
    public string ConnectionString { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}
