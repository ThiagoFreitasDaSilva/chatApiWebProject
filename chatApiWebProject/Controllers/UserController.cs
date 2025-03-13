using Microsoft.AspNetCore.Mvc;
using SignalRChatServer.Services;

namespace SignalRChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
           this._userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getUsers() {
            var user = await _userService.getAllUsersAsync();
            return Ok(user);

        }
    }
}