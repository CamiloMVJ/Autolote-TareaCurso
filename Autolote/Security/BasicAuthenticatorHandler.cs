using AutoloteAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace AutoloteAPI.Security
{
    public class BasicAuthenticatorHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUsurioRepository _userRepository;

        public BasicAuthenticatorHandler(IUsurioRepository repoUser, IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _userRepository = repoUser;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No viene el header");

            bool result = false;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                result = _userRepository.IsUser(username, password);
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }

            if (!result)
                return AuthenticateResult.Fail("Usuario o contraseña inválida");

            var claims = new Claim[]
            {
                        new Claim(ClaimTypes.NameIdentifier, "id"),
                        new Claim(ClaimTypes.Name, "user")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);

        }
    }
}
