using Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Hubs;
public class MessageHub : Hub
{
    // Method that sends the message to everyone connected to this hub
    public async Task SendMessage(string username, string message)
    {
        // Will only pass in username and message
        await Clients.All.SendAsync("MessageReceived", username, message);
    }
}