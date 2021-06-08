using System;
using System.ComponentModel.DataAnnotations;
using Peep.Parrot.Domain.Enums;

namespace Peep.Parrot.Domain.Dtos
{
    public class AddPeepDto
    {
        public Guid PeepId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        [Required]
        public EPeepSource Source { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsQuote { get; set; }

        public Guid QuotedPeepId { get; set; }

        [Required]
        public EPeepReplyRestriction ReplyRestriction { get; set; }
    }
}
