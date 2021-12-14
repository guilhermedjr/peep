using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.Hub;

namespace Peep.Parrot.Hubs;

public class TimelineHub : Hub, ITimelineHub 
{
    public async override Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Message", "Connected successfully!");
    }

    public Task StartTimelineLive(ApplicationUser user)
    {
        throw new System.NotImplementedException();
    }

    public Task StopTimelineLive(ApplicationUser user)
    {
        throw new System.NotImplementedException();
    }
}

