namespace Jerkoder.Common.Domain.Database;

public class DatabaseSqlServerOptions
{
    public string ConnectionString { get; set; } = string.Empty;
    public int MaxRetryCount { get; init; }
    public int CommandTimeout { get; init; }
    public bool EnableDetailedErrors { get; init; }
    public bool EnableSensitiveDataLogging { get; init; }
}
