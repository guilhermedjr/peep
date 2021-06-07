using System;
using System.ComponentModel.DataAnnotations;
using Peep.Parrot.Domain.Enums;

namespace Peep.Parrot.Domain.Dtos
{
    public class AddPeepDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool IsQuote { get; set; }

        public Entities.Peep QuotedPeep { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public EPeepSource Source { get; set; }
        [Required]
        public EPeepReplyRestriction ReplyRestriction { get; set; }
    }
}
