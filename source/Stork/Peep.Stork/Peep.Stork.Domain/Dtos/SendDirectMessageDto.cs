using System;
using System.ComponentModel.DataAnnotations;

namespace Peep.Stork.Domain.Dtos
{
    public class SendDirectMessageDto
    {
        [Required]
        public Guid SenderId { get; set; }
        [Required]
        public Guid ReceiverId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}

