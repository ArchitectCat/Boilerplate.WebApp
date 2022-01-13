using System.Collections.Generic;
using Boilerplate.Api.Models;
using Boilerplate.Identity.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("authorization")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthorizationController(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [AllowAnonymous]
        [HttpPost("connect/token")]
        public IActionResult GetAuthorizationToken(JwtTokenRequest request)
        {
            var token = _tokenGenerator.Generate(request?.Claims ?? new Dictionary<string, string>());
            return Ok(new JwtTokenResponse()
            {
                AccessToken = token.AccessToken,
                Expires = (int) token.Expires.TotalSeconds
            });
        }
    }
}