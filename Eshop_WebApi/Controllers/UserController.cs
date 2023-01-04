using Eshop_Domain.DTO;
using Eshop_Service.Interfaces;
using Eshop_Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("registeruser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userEntity)
        {
            try
            {
                int userId = await _userService.Create(userEntity);

                return Ok(userId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("loginuser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            try
            {
                var jwt = await _userService.Login(loginModel);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
