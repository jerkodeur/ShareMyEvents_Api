using Microsoft.Extensions.Options;

namespace ShareMyEvents.Api.Configuration.OptionsSetup;

internal class DatabaseOptionsSetup: IConfigureOptions<DatabaseSqlServerOptions>
{
    private const string SECTION_NAME = "Database:Options";

    private readonly IConfiguration _configuration;

    public DatabaseOptionsSetup (IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public void Configure (DatabaseSqlServerOptions options)
    {
        var connectionString = _configuration.GetConnectionString("ShareMyEventsApiContext") ?? throw new InvalidOperationException("Connection string 'ShareMyEventsApiContext' not found.");
        options.ConnectionString = connectionString;

        _configuration.GetSection(SECTION_NAME).Bind(options);
    }
}
