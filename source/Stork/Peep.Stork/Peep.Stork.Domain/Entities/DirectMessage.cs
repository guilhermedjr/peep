using System;

namespace Peep.Stork.Domain.Entities
{
    public class DirectMessage
    {
        public Guid Id { get; set; }
        public User Sender { get; set; }
        public Guid SenderId { get; set; }
        public User Receiver { get; set; }
        public Guid ReceiverId { get; set; }
        public string Text { get; set; }
        public bool Sent { get; set; }
        public bool Seen { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? SeenAt { get; set; }
    }
}
