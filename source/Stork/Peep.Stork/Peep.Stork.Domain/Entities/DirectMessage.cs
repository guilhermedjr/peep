using System;

namespace Peep.Stork.Domain.Entities
{
    public class DirectMessage
    {
        public Guid Id { get; set; }
        public ApplicationUser Sender { get; set; }
        public Guid SenderId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public Guid ReceiverId { get; set; }
        public string Text { get; set; }
        public bool Sent { get; set; }
        public bool Seen { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? SeenAt { get; set; }

        public void MarkAsSent()
        {
            Sent = true;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsSeen()
        {
            Seen = true;
            SeenAt = DateTime.UtcNow;
        }
    }
}
