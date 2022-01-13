using System.Collections.Generic;

namespace Boilerplate.Api.Models
{
    public sealed class JwtTokenRequest
    {
        public Dictionary<string, string> Claims { get; set; }
    }
}