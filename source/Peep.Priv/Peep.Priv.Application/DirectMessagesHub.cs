using Microsoft.AspNetCore.SignalR;
namespace Peep.Priv.Application;

public class DirectMessagesHub : Hub
{
    public async override Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Message", "Connected successfully!");
    }

    public Task SendDirectMessage(Guid to, string textContent)
    {
        Guid from = Context.User.
    }
}
