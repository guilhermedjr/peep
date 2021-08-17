using System;
using System.Threading.Tasks;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.ViewModels;

namespace Peep.Parrot.Domain.Repository
{
    public interface IUserInfoRepository
    {
        bool AddUserInfo(AddUserInfoDto addUserInfoDto);
        Task<UserInfoViewModel> GetUserInfo(Guid id);
        bool UpdateUserInfo(UpdateUserInfoDto updateUserInfoDto);
        Task<bool> DeleteUserInfo(Guid id);
    }
}
