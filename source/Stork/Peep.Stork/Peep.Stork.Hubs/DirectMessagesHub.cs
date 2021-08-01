using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Peep.Stork.Domain.Dtos;
using Peep.Stork.Domain.Hubs;

namespace Peep.Stork.Hubs
{
    public class DirectMessagesHub : Hub, IDirectMessagesHub
    {
        public async Task SendDirectMessage(SendDirectMessageDto sendDirectMessageDto)
        {
            await Clients.Client(sendDirectMessageDto.Receiver.ToString())
              .SendAsync("Receive", sendDirectMessageDto.Sender, sendDirectMessageDto.Text);
        }
    }
}
