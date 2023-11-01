using Microsoft.Extensions.Options;
using ShareMyEvents.Api.Configuration.Authentication;

namespace ShareMyEvents.Api.Configuration.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string SECTION_NAME = "Jwt";
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public void Configure (JwtOptions options)
    {
        _configuration.GetSection(SECTION_NAME).Bind(options);
    }
}
