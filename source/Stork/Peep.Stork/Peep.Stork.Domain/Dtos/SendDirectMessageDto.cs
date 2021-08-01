using Peep.Stork.Domain.Entities;

namespace Peep.Stork.Domain.Dtos
{
    public class SendDirectMessageDto
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string Text { get; set; }
    }
}

