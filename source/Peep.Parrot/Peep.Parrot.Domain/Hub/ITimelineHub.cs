namespace Peep.Parrot.Domain.Hub;

public interface ITimelineHub
{
    Task StartTimelineLive(ApplicationUser user);
    Task StopTimelineLive(ApplicationUser user);
}

