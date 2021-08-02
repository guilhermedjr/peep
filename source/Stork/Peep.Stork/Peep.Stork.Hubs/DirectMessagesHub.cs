using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Peep.Stork.Domain.Entities;
using Peep.Stork.Domain.Dtos;
using Peep.Stork.Domain.Hub;

namespace Peep.Stork.Hubs
{
    public class DirectMessagesHub : Hub, IDirectMessagesHub
    {
        public async Task SendDirectMessage(SendDirectMessageDto sendDirectMessageDto)
        {
            await Clients.Client(sendDirectMessageDto.ReceiverId.ToString())
              .SendAsync("ReceiveDirectMessage", sendDirectMessageDto.SenderId, sendDirectMessageDto.Text);
        }
        
    }
}
