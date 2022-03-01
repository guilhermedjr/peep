using System.Text.Json;
using Peep.Search.Domain.Entities;

namespace Peep.Search.Domain.Handler;

public interface ISearchHandler
{
    Task<JsonDocument> Search(string searchString);
    Task<IEnumerable<User>> SearchUsers(string searchString);
}

