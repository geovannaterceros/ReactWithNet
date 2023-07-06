using Microsoft.AspNetCore.Mvc;
using ProgramsManager.BL.Authorization;

namespace ProgramsManager.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IConfiguration _configuration;

        public AuthorizationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetToken()
        {
            string key = _configuration["Authentication:SecretKey"];
            string issuer = _configuration["Authentication:Issuer"];
            string audience = _configuration["Authentication:Audience"];
            DateTime timeExpiration = DateTime.Now.AddSeconds(30);
            string email = "xyz@xyz.com";
            string name = "xyz";
            string token = GenerateToken.GetToken(key, timeExpiration, email, name , issuer,  audience);
            return Ok(new { Token = token, Expiration = timeExpiration });
        }
    }
}
