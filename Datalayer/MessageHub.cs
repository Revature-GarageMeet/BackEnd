using Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Hubs 
{
    public class MessageHub:Hub
    {
        public async Task NewMessage(string user, string message)
        {
            await Clients.All.SendAsync("MessageReceived", user, message);
        }
    }
}