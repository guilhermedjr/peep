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

        public bool AddPeep(AddPeepDto addPeepDto)
        {
            var now = DateTime.Now;
            var peepId = Guid.NewGuid();

            addPeepDto.PeepId = peepId;
            addPeepDto.Date = now.Date;
            addPeepDto.Time = now.TimeOfDay;

            if (base.CreateHash<AddPeepDto>($"peep:{peepId}", addPeepDto))
            {
                base.AddGuidToListHead($"peeps_user:{addPeepDto.UserId}", peepId);
                return true;
            }
            return false;
        }
            
        public Task EditPeep(Guid userId, EditPeepDto editPeepDto)
        {
            throw new NotImplementedException();
        }

        public Task DeletePeep(Guid userId, Guid peepId)
        {
            throw new NotImplementedException();
        }
    }
}
