namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeepsController : ControllerBase
{
    private readonly IPeepsRepository _peepsRepository;

    public PeepsController(
        IPeepsRepository peepsRepository)
    {
        _peepsRepository = peepsRepository;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddPeep([FromBody] AddPeepDto addPeepDto)
    {
        if (String.IsNullOrEmpty(addPeepDto.UserId.ToString()))
            return BadRequest(new { Message = "User Id not specified" });

        await _peepsRepository.AddPeep(addPeepDto);
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetPeep([FromQuery] Guid id) 
    {
        var peep = await _peepsRepository.GetById(id);

        if (peep == null)
            return BadRequest(new { Message = "There is no peep with the specified id" });

        return Ok(peep);
    }
}

