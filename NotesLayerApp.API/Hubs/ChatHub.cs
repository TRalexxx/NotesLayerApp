using Microsoft.AspNetCore.SignalR;

namespace NotesLayerApp.API.Hubs;

public class ChatHub : Hub
{
    public async Task Send(string message)
    {
        await this.Clients.All.SendAsync("Receive", message);
    }
}
