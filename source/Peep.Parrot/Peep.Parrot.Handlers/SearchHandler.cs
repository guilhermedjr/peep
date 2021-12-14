using Peep.Parrot.Domain.Handler;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Domain.Entities;
using System.Text.Json;

namespace Peep.Parrot.Handlers;

public class SearchHandler : ISearchHandler
{
    private readonly ISearchRepository<ApplicationUser> _usersSearchRepository;

    public SearchHandler(
        ISearchRepository<ApplicationUser> usersSearchRepository
        )
    {
        _usersSearchRepository = usersSearchRepository;
    }

    /// <summary>
    /// Access the repositories that implement ISearchRepository<T> and 
    /// returns a JSON document with all the results that match the search string
    /// </summary>
    /// <param name="searchString"></param>
    /// <exception cref="NotImplementedException"></exception>
    public Task<JsonDocument> Search(string searchString)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Access ISearchRepository<ApplicationUser> and returns the users that match the search string
    /// </summary>
    /// <param name="searchString"></param>
    /// <remarks>
    /// Provisional method. It must be replaced by the Search method defined by ISearchHandler,
    /// which must be implemented once more than one search repository is accessed.
    /// </remarks>
    public async Task<IEnumerable<ApplicationUser>> SearchUsers(string searchString) =>
        await _usersSearchRepository.Search(searchString);
}

