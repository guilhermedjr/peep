using System;

namespace Peep.Stork.Domain.Dtos
{
    public class SendDirectMessageDto
    {
        public Guid Sender { get; set; }
        public Guid Receiver { get; set; }
        public string Text { get; set; }
        public string[] MediaURLs { get; set; }
    }
}
