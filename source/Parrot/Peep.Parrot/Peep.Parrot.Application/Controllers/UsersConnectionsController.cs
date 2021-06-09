using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.Repository;

namespace Peep.Parrot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersConnectionsController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IUsersConnectionsRepository _usersConnectionsRepository;

        public UsersConnectionsController(
            IDistributedCache cache,
            IUsersConnectionsRepository usersConnectionsRepository)
        {
            this._cache = cache;
            this._usersConnectionsRepository = usersConnectionsRepository;
        }

        [HttpPost]
        [Route("RequestFollowUp")]
        public async Task<IActionResult> RequestFollowUp(
            [FromQuery] Guid requestingUserId, [FromQuery] Guid requestedUserId)
        {
            if (String.IsNullOrEmpty(requestingUserId.ToString()) ||
                String.IsNullOrEmpty(requestedUserId.ToString()))
            {
                return BadRequest(new { Message = "Parameters are null" });
            }

            if (requestingUserId == requestedUserId)
                return BadRequest(new { Message = "The Requesting User Id and the Requested User Id are the same" });

            if (await _usersConnectionsRepository.RequestFollowUp(requestingUserId, requestedUserId))
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("RemoveFollowUpRequest")]
        public async Task<IActionResult> RemoveFollowUpRequest(
            [FromQuery] Guid requestingUserId, [FromQuery] Guid requestedUserId)
        {
            if (String.IsNullOrEmpty(requestingUserId.ToString()) ||
               String.IsNullOrEmpty(requestedUserId.ToString()))
            {
                return BadRequest(new { Message = "Parameters are null" });
            }

            if (requestingUserId == requestedUserId)
                return BadRequest(new { Message = "The Requesting User Id and the Requested User Id are the same" });

            if (await _usersConnectionsRepository.RemoveFollowUpRequest(requestingUserId, requestedUserId))
                return NoContent();
            return BadRequest();
        }

        [HttpGet]
        [Route("GetUserFollowUpRequests")]
        public async Task<IActionResult> GetUserFollowUpRequests([FromQuery] Guid userId)
        {
            if (String.IsNullOrEmpty(userId.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            var requests = await _usersConnectionsRepository.GetUserFollowUpRequests(userId);

            if (requests != null)
                return Ok(requests);
            return NotFound(new { Message = "The user does not have followup requests" });
            
        }

        [HttpPost]
        [Route("AddFollowUp")]
        public async Task<IActionResult> AddFollowUp(
            [FromQuery] Guid followerId, [FromQuery] Guid followedId)
        {
            if (String.IsNullOrEmpty(followerId.ToString()) ||
               String.IsNullOrEmpty(followedId.ToString()))
            {
                return BadRequest(new { Message = "Parameters are null" });
            }

            if (followerId == followedId)
                return BadRequest(new { Message = "The Follower Id and the Followed Id are the same" });

            if (await _usersConnectionsRepository.AddFollowUp(followerId, followedId))
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        [Route("RemoveFollowUp")]
        public async Task<IActionResult> RemoveFollowUp(
            [FromQuery] Guid followerId, [FromQuery] Guid followedId)
        {
            if (String.IsNullOrEmpty(followerId.ToString()) ||
               String.IsNullOrEmpty(followedId.ToString()))
            {
                return BadRequest(new { Message = "Parameters are null" });
            }

            if (followerId == followedId)
                return BadRequest(new { Message = "The Follower Id and the Followed Id are the same" });

            if (await _usersConnectionsRepository.RemoveFollowUp(followerId, followedId))
                return NoContent();
            return BadRequest();
        }
    }
}
