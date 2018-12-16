using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListing.Auth.TokenAuth
{
    public class  TokenAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "Token Auth";
        public  string[] AuthKeys { get; set; }
    }
}
