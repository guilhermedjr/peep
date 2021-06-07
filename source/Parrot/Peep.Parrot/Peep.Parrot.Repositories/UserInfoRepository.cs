using System;
using Microsoft.Extensions.Configuration;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Repository;
using System.Threading.Tasks;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Domain.Entities;
using Peep.Parrot.Domain.ViewModels;

namespace Peep.Parrot.Repositories
{
    public class UserInfoRepository : RedisDbConnection, IUserInfoRepository
    {
        public UserInfoRepository(IConfiguration config): base(config) {}

        public bool AddUserInfo(AddUserInfoDto addUserInfoDto) =>
            base.CreateHash<AddUserInfoDto>($"user:{addUserInfoDto.Id}", addUserInfoDto);

        public async Task<UserInfoViewModel> GetUserInfo(Guid id) =>
            await base.GetObjectFromKey<UserInfoViewModel>($"user:{id}");

        public bool UpdateUserInfo(UpdateUserInfoDto updateUserInfoDto) =>
            base.UpdateHashFromKey($"user:{updateUserInfoDto.Id}", updateUserInfoDto);

        public Task<bool> DeleteUserInfo(Guid id) =>
            base.DeleteKey($"user:{id}");
    }
}
