using Microsoft.AspNetCore.SignalR;
namespace Peep.Parrot.Application;

public class TimelineHub : Hub
{
    public async override Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Message", "Connected successfully!");
    }

    [HubMethodName("updateTimeline")]
    public static Task UpdateTimeline()
    {
        return Task.CompletedTask;
    }
}
