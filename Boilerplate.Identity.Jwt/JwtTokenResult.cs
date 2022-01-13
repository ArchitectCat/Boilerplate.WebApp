using System;

namespace Boilerplate.Identity.Jwt
{
    public sealed class JwtTokenResult
    {
        public string AccessToken { get; internal set; }
        public TimeSpan Expires { get; internal set; }
    }
}