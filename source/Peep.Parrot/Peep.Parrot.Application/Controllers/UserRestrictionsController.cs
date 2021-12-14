namespace Peep.Parrot.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRestrictionsController : ControllerBase
{
    private readonly IUserRestrictionsRepository _userRestrictionsRepository;

    public UserRestrictionsController(
        IUserRestrictionsRepository userRestrictionsRepository)
    {
        this._userRestrictionsRepository = userRestrictionsRepository;
    }

    [Authorize]
    [HttpPut]
    public IActionResult ChangeAccountVisibility([FromQuery] Guid userId)
    {
        if (String.IsNullOrEmpty(userId.ToString()))
            return BadRequest(new { Message = "User Id not specified" });

            _userRestrictionsRepository.ChangeAccountVisibility(userId);
            return NoContent();
    }

    [Authorize]
    [HttpPost]
    [Route("MuteUser")]
    public async Task<IActionResult> MuteUser([FromQuery] Guid mufflerId, [FromQuery] Guid mutedUserId)
    {
        if (String.IsNullOrEmpty(mufflerId.ToString()) ||
            String.IsNullOrEmpty(mutedUserId.ToString()))
        {
            return BadRequest(new { Message = "Parameters are null" });
        }

        if (mufflerId == mutedUserId)
            return BadRequest(new { Message = "The Muffler Id and the Muted User Id are the same" });

        if (await _userRestrictionsRepository.MuteUser(mufflerId, mutedUserId))
            return Ok();
        return BadRequest();
    }

    [Authorize]
    [HttpPost]
    [Route("BlockUser")]
    public async Task<IActionResult> BlockUser([FromQuery] Guid blockingUserId, [FromQuery] Guid blockedUserId)
    {
        if (String.IsNullOrEmpty(blockingUserId.ToString()) ||
            String.IsNullOrEmpty(blockedUserId.ToString()))
        {
            return BadRequest(new { Message = "Parameters are null" });
        }

        if (blockingUserId == blockedUserId)
            return BadRequest(new { Message = "The Blocking User Id and the Blocked User Id are the same" });

        if (await _userRestrictionsRepository.BlockUser(blockingUserId, blockedUserId))
            return Ok();
        return BadRequest();
    }

    [Authorize]
    [HttpDelete]
    [Route("UnmuteUser")]
    public async Task<IActionResult> UnmuteUser([FromQuery] Guid mufflerId, [FromQuery] Guid mutedUserId)
    {
        if (String.IsNullOrEmpty(mufflerId.ToString()) ||
            String.IsNullOrEmpty(mutedUserId.ToString()))
        {
            return BadRequest(new { Message = "Parameters are null" });
        }

        if (mufflerId == mutedUserId)
            return BadRequest(new { Message = "The Muffler Id and the Muted User Id are the same" });

        if (await _userRestrictionsRepository.UnmuteUser(mufflerId, mutedUserId))
            return NoContent();
        return BadRequest();
    }

    [Authorize]
    [HttpDelete]
    [Route("UnblockUser")]
    public async Task<IActionResult> UnblockUser([FromQuery] Guid blockingUserId, [FromQuery] Guid blockedUserId)
    {
        if (String.IsNullOrEmpty(blockingUserId.ToString()) ||
            String.IsNullOrEmpty(blockedUserId.ToString()))
        {
            return BadRequest(new { Message = "Parameters are null" });
        }

        if (blockingUserId == blockedUserId)
            return BadRequest(new { Message = "The Blocking User Id and the Blocked User Id are the same" });

        if (await _userRestrictionsRepository.UnblockUser(blockingUserId, blockedUserId))
            return NoContent();
        return BadRequest();
    }

}

