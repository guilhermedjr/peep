using System;
using System.Collections.Generic;
using System.Text;

namespace Peep.Wings.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Password { get; set; }
    }
}
