using System.Collections.Generic;

namespace Boilerplate.Identity.Jwt
{
    public interface IJwtTokenGenerator
    {
        JwtTokenResult Generate(IDictionary<string, string> claims);
    }
}