using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.Repository;

namespace Peep.Parrot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeepsController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IPeepsRepository _peepsRepository;

        public PeepsController(
            IDistributedCache cache,
            IPeepsRepository peepsRepository)
        {
            this._cache = cache;
            this._peepsRepository = peepsRepository;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPeep(AddPeepDto addPeepDto)
        {
            if (String.IsNullOrEmpty(addPeepDto.UserId.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (await _peepsRepository.AddPeep(addPeepDto))
                return Ok();
            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> EditPeep(EditPeepDto editPeepDto)
        {
            if (String.IsNullOrEmpty(editPeepDto.UserId.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (await _peepsRepository.EditPeep(editPeepDto))
                return NoContent();
            return BadRequest();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePeep([FromQuery] Guid userId, Guid peepId)
        {
            if (String.IsNullOrEmpty(userId.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (await _peepsRepository.DeletePeep(userId, peepId))
                return NoContent();
            return BadRequest();
        }

    }
}
