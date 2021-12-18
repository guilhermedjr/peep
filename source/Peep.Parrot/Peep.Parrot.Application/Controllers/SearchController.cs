namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly ISearchHandler _searchHandler;

    public SearchController(
        ISearchHandler searchHandler
        )
    {
        _searchHandler = searchHandler;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string s)
    {
        if (s.Length == 0)
            return BadRequest();

        var results = await _searchHandler.SearchUsers(s);
        return Ok(results);
    }
}

