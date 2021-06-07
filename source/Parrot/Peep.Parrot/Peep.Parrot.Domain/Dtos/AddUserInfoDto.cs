using System;
using System.ComponentModel.DataAnnotations;

namespace Peep.Parrot.Domain.Dtos
{
    public class AddUserInfoDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Website { get; set; }
    }
}
