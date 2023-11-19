using CleanArcihtecture.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    public sealed class JwtOptionSetup : IConfigureOptions<JwtOption>
    {
        private readonly IConfiguration _configuration;

        public JwtOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOption options)
        {
            _configuration.GetSection("Jwt").Bind(options);
        }
    }
}
