using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;

namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    
    private readonly AppDbContext _appDbContext;
    private readonly IUsersRepository _usersRepository;
    private readonly IPeepsRepository _peepsRepository;

    public UsersController(
        AppDbContext appDbContext,
        IUsersRepository usersRepository,
        IPeepsRepository peepsRepository
        )
    {
        _appDbContext = appDbContext;

       

        _peepsRepository = peepsRepository;
    }

    [Authorize]
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await _usersRepository.GetById(id);

        if (user == null)
            return NotFound();

        var userPeeps = Enumerable.ToList(await _peepsRepository.GetUserPeeps(id));

        if (userPeeps.Count > 0)
        {
            foreach (var peep in userPeeps)
            {
                var normalizedPeep = await _appDbContext.Peep.FindAsync(peep.Id);
                peep.PublicationDate = normalizedPeep.PublicationDate;
                peep.PublicationTime = normalizedPeep.PublicationTime;
            }

            user.Peeps = userPeeps
                .OrderByDescending(p => p.PublicationDate).OrderByDescending(p => p.PublicationTime).ToList();
        }

        return Ok(user);
    }
}


