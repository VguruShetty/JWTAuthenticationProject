using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entites;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static User? user = new();
        [HttpPost("Register")]
        public ActionResult<User?> Register([FromBody] UserDto request)
        {
            user.Username = request.Username;
            user.PasswordHash = new PasswordHasher<User>()
                .HashPassword(user, request.PasswordHash);
            return Ok(user);
        }
        public ActionResult<User?> Login([FromBody] UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }
            var result = new PasswordHasher<User>()
                .VerifyHashedPassword(user, user.PasswordHash, request.PasswordHash);
            if (result == PasswordVerificationResult.Failed)
            {
                return BadRequest("Wrong password");
            }
            return Ok(user);
        }
    }
}
