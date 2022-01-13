namespace Boilerplate.Api.Models
{
    public sealed class JwtTokenResponse
    {
        public string AccessToken { get; set; }
        public int Expires { get; set; }
    }
}