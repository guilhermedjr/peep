using System.Text.Json;
namespace Peep.Parrot.Domain.Handler;

public interface ISearchHandler
{
    Task<JsonDocument> Search(string searchString);
    Task<IEnumerable<ApplicationUser>> SearchUsers(string searchString);
}
