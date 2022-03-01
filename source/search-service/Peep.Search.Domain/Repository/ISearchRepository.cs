namespace Peep.Search.Domain.Repository;

public interface ISearchRepository<T> where T : class
{
    Task<IEnumerable<T>> Search(string searchString);
}

