using Authentication.API.Dtos;
using Authentication.API.Security;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("/AuthModule")]
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;

        public UserController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Authentication Module");
        }

        [HttpPost("/login")]
        public Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.UserName == "admin")
            {
                var token = _jwtCreator.GenerateJsonWebToken("admin");
                var loginResponse = new LoginResponse { token = token };
                return Task.FromResult<IActionResult>(Ok(loginResponse));
            }

            return Task.FromResult<IActionResult>(Unauthorized());
        }
    }
}