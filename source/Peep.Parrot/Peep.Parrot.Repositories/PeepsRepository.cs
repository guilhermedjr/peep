using Microsoft.EntityFrameworkCore;
namespace Peep.Parrot.Repositories;

public class PeepsRepository : IPeepsRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Domain.Entities.Peep> _peeps;

    public PeepsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _peeps = appDbContext.Set<Domain.Entities.Peep>();
    }

    public Task<Domain.Entities.Peep> AddPeep(Domain.Entities.Peep peep)
    {
        _peeps.Add(peep);
        _appDbContext.SaveChanges();
    }

    public Task<Domain.Entities.Peep> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.Peep>> GetUserPeeps(Guid userId)
    {
        throw new NotImplementedException();
    }
}
