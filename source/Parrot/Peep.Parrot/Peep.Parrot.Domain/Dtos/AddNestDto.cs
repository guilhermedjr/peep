using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Domain.Dtos
{
    public class AddNestDto
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        public string Description { get; set; }

        [Required]
        public List<User> Members { get; set; }
    }
}
