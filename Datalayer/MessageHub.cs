using Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Hubs;

public class MessageHub:Hub
{
    public async Task NewMessage(ChatMessage msg)
    {
        await Clients.All.SendAsync("MessageReceived", msg);
    }
}