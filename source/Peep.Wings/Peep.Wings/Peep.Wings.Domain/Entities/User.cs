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
    }
}
