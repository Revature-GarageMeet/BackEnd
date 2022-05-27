using Microsoft.AspNetCore.Mvc;
using Datalayer;
using Models;
using Microsoft.AspNetCore.SignalR;
using Hubs;

namespace WebAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    //private readonly DBInterface _db;
    private readonly IHubContext<MessageHub> _hc;
    public ChatController(IHubContext<MessageHub> hc)
    {
        _hc = hc; 
    }

    [Route("send")]
    [HttpPost]
    public IActionResult SendRequest([FromBody] ChatMessage msg)
    {
        _hc.Clients.All.SendAsync("MessageReceived", msg.username, msg.message);
        return Ok();
    }
}
