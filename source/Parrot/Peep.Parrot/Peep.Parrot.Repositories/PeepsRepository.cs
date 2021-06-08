using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Infrastructure.Data;

namespace Peep.Parrot.Repositories
{
    public class PeepsRepository : RedisDbConnection, IPeepsRepository
    {
        public PeepsRepository(IConfiguration config): base(config) {}

        public async Task <bool> AddPeep(AddPeepDto addPeepDto)
        {
            var now = DateTime.Now;
            var peepId = Guid.NewGuid();

            addPeepDto.PeepId = peepId;
            addPeepDto.Date = now.Date;
            addPeepDto.Time = now.TimeOfDay;

            if (base.CreateHash<AddPeepDto>($"peep:{peepId}", addPeepDto))
            {
                return await base.AddGuidOnSet($"peeps_user:{addPeepDto.UserId}", peepId);
            }
            return false;
        }
            
        public async Task<bool> EditPeep(EditPeepDto editPeepDto)
        {
            if (base.GetObjectFromKey<EditPeepDto>($"peep:{editPeepDto.PeepId}") != null)
            {
                if (await base.GuidIsOnSet($"peeps_user:{editPeepDto.UserId}", editPeepDto.PeepId))
                {
                    return base.UpdateHashFromKey<EditPeepDto>($"peep:{editPeepDto.PeepId}", editPeepDto);
                }
                return false;
            }
            return false;
        }
       
        public async Task<bool> DeletePeep(Guid userId, Guid peepId)
        {
            if (await base.DeleteGuidOfSet($"peeps_user:{userId}", peepId))
            {
                return await base.DeleteKey($"peep:{peepId}");
            }
            return false;
        }
    }
}
