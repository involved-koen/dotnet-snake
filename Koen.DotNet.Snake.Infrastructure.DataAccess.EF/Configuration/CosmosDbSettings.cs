namespace Koen.DotNet.Snake.Infrastructure.DataAccess.EF.Configuration;

public class CosmosDbSettings
{
    public string Endpoint { get; init; } = string.Empty;
    public string Key { get; init; } = string.Empty;
    public string Database { get; init; } = string.Empty;
}