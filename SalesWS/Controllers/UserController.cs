using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWS.Models.Response;
using SalesWS.Models.ViewModels;
using SalesWS.Services;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Auth([FromBody] AuthViewModel auth)
        {
            var response = new ApiResponse();
            var userResponse = _userService.Auth(auth);
            if (userResponse == null)
            {
                response.Message = "Usuario o Password Erroneo";
                return BadRequest(response);
            }
            response.Success = 1;
            response.Data = userResponse;
            return Ok(response);
        }
    }
}
