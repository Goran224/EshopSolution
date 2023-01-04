using Eshop_Domain.DTO;
using Eshop_Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("test")]

        private ActionResult GetUser()
        {
            var isAdmin = User.FindFirst("isAdmin")?.Value;
            var email = User.FindFirst("Email")?.Value;
            if (Convert.ToBoolean(isAdmin))
            {
                Console.WriteLine("Is Admin");
            }

            return Ok();
        }

        private UserDto ConvertToInt32(string? userId)
        {
            throw new NotImplementedException();
        }
    }
}
