using Peep.Timeline.Entities;
namespace Peep.Timeline.Interfaces;

public interface ITimelineHub
{
   Task StartTimelineLive(User user);
   Task StopTimelineLive(User user);
}
