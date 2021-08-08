using System;
using System.Collections.Generic;
using System.Text;

namespace Peep.Wings.Domain.Dtos
{
    public class UpdateAccountDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
