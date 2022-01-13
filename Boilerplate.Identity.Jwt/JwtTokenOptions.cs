using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Boilerplate.Identity.Jwt
{
    public sealed class JwtTokenOptions
    {
        public string Issuer { get; }
        public string Audience { get; }
        public SecurityKey SigningKey { get; }
        public int TokenExpirationInMinutes { get; }
        
        public JwtTokenOptions(
            string issuer,
            string audience,
            string signingKey,
            int tokenExpirationInMinutes)
        { 
            Issuer = issuer;
            Audience = audience;
            SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey));
            TokenExpirationInMinutes = tokenExpirationInMinutes;
        }
    }
}