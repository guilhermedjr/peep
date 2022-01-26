namespace Peep.Parrot.Domain.Repository;

public interface IUsersRepository
{
    Task<ApplicationUser> GetById(Guid id);
}

