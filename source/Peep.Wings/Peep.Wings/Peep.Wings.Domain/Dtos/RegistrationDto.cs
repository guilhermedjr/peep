using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Peep.Wings.Domain.Dtos
{
    public class RegistrationDto
    {
        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
