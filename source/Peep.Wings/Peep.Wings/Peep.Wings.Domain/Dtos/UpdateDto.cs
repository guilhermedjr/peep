using System;
using System.Collections.Generic;
using System.Text;

namespace Peep.Wings.Domain.Dtos
{
    public class UpdateAccountDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
