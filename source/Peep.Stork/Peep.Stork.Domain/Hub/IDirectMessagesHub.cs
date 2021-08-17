using System.Threading.Tasks;
using Peep.Stork.Domain.Dtos;

namespace Peep.Stork.Domain.Hub
{
    public interface IDirectMessagesHub
    {
        Task SendDirectMessage(SendDirectMessageDto sendDirectMessageDto);
    }
}
