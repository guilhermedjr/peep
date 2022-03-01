using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Peep.TimelineService.Entities;
using Peep.Timeline.Interfaces;
using Peep.Timeline.Entities;

namespace Peep.Timeline.Hubs;

public class TimelineHub : Hub, ITimelineHub
{
    public async override Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        await Clients.Caller.SendAsync("Message", "Connected successfully!");
    }

    public Task StartTimelineLive(User user)
    {
        throw new System.NotImplementedException();
    }

    public Task StopTimelineLive(User user)
    {
        throw new System.NotImplementedException();
    }
}

