using Microsoft.AspNetCore.Mvc;
using SignalRChatServer.Services;

namespace SignalRChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IConnectionService _connectionService;
        public ConnectionController(IConnectionService connectionService) {
           this._connectionService = connectionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getConnections() {
            var connections = await _connectionService.getAllConnectionsAsync();
            return Ok(connections);
        }

        [HttpGet("{userID}")]
        public async Task<IActionResult> getConnectionByUserID(int userID) {
            return Ok();
        }
    }
}