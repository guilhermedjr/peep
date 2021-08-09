using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Peep.Wings.Domain.Dtos
{
    public class AssociateExternalLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public bool AssociateExistingAccount { get; set; }

        public string ExistingAccountEmail { get; set; }

        [Required]
        public string LoginProvider { get; set; }
        [Required]
        public string ProviderDisplayName { get; set; }
        [Required]
        public string ProviderKey { get; set; }
    }
}
