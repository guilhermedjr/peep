using System.Threading.Tasks;
using Peep.Parrot.Domain.Dtos;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUserInfoRepository
    {
        Task UpdateUserInfo(UpdateUserInfoDto updateUserInfoDto);
    }
}
