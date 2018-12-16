using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace TodoListing.Auth.TokenAuth
{
    public class TokenAuthHandler : AuthenticationHandler<TokenAuthOptions>
    {
        public TokenAuthHandler(IOptionsMonitor<TokenAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
           : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var apiKey = Request.Headers["ApiKey"];
            // Get Authorization header value
            if(string.IsNullOrEmpty(apiKey))
            {
                return Task.FromResult(AuthenticateResult.Fail("Cannot read ApiKey header."));
            }

            // The api key from ApiKey header check against the configured ones
            if (!Options.AuthKeys.Any(key => key == apiKey))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid auth key."));
            }

            // Create authenticated user
            var identities = new List<ClaimsIdentity> { new ClaimsIdentity("Token Auth") };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
