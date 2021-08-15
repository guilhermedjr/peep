using System.Threading.Tasks;
using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Domain.Hub
{
    public interface ITimelineHub
    {
        Task StartTimelineLive(User user);
        Task StopTimelineLive(User user);
    }
}
