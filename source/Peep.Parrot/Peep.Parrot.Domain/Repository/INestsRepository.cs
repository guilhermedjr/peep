namespace Peep.Parrot.Domain.Repository;

public interface INestsRepository
{
    Task AddNest(AddNestDto addNestDto);
    Task EditNest(EditNestDto editNestDto);
    Task AddNestMembers(Guid nestId, IEnumerable<ApplicationUser> members);
    Task DeleteNest(Guid ownerId, Guid nestId);
}

