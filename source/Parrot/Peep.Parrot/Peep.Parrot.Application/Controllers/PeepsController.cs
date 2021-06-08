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

        [HttpPost]
        public IActionResult AddPeep(AddPeepDto addPeepDto)
        {
            if (String.IsNullOrEmpty(addPeepDto.UserId.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (_peepsRepository.AddPeep(addPeepDto))
                return Ok();
            return BadRequest();
        }

    }
}
