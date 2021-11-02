namespace Peep.Wings.Domain.Dtos;

public class AssociateExternalLoginDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }
    [Required]
    public bool AssociateToExistingAccount { get; set; }

    public string ExistingAccountEmail { get; set; }

    [Required]
    public string LoginProvider { get; set; }
       
    public string ProviderDisplayName { get; set; }
    public string ProviderKey { get; set; }
}

