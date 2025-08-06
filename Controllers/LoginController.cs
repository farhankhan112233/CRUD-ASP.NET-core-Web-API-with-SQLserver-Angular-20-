using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Representational_State_Transfer.Interfaces;
using Representational_State_Transfer.Models.Entities;

namespace Representational_State_Transfer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _token;
        public LoginController(ITokenService token)
        {
            _token = token;
        }
        [HttpPost]
        public IActionResult loginJWT([FromBody] Login log)
        {
            string hash = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9";

            if (log.username == "admin" && log.password == hash)
            {

                var token = _token.GenerateToken(log.username);
                return Ok(new { token });
            }
            return NoContent();
        }

    }
}
