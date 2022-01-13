using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Boilerplate.Identity.Jwt
{
    public sealed class JwtTokenGenerator
        : IJwtTokenGenerator
    {
        private readonly JwtTokenOptions _options;

        public JwtTokenGenerator(JwtTokenOptions options)
        {
            _options = options;
        }

        public JwtTokenResult Generate(IDictionary<string, string> claims)
        {
            var tokenExpiration = TimeSpan.FromMinutes(_options.TokenExpirationInMinutes);
            var tokenClaims = claims.Select(x => new Claim(x.Key, x.Value));
                
            var jwt = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                tokenClaims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(tokenExpiration),
                new SigningCredentials(_options.SigningKey,SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtTokenResult
            {
                AccessToken = accessToken,
                Expires = tokenExpiration
            };
        }
    }
}