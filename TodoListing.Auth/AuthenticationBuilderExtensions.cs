using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using TodoListing.Auth.TokenAuth;

namespace TodoListing.Auth
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddTokenAuth(this AuthenticationBuilder builder, Action<TokenAuthOptions> configureOptions)
        {
            // Add custom authentication scheme with custom options and custom handler
            return builder.AddScheme<TokenAuthOptions, TokenAuthHandler>(TokenAuthOptions.DefaultScheme, configureOptions);
        }
    }
}
