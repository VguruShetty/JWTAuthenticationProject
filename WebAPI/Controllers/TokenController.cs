using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenGeneratorService _tokenGeneratorService;
        public TokenController(ITokenGeneratorService tokenGeneratorService)
        {
            _tokenGeneratorService = tokenGeneratorService;
        }
        [HttpGet]
        [Route("generate/{username}/{password}")]
        public IActionResult Get(string username, string password)
        {
            if(username == "admin" || password == "password")
            {
               var accessToken = _tokenGeneratorService.GenerateToken(username, password);
               return Ok(accessToken);
            }
            return Unauthorized();
        }
    }
}
