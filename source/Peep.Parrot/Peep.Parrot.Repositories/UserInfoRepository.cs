using System;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Repository;
using System.Threading.Tasks;
using Peep.Parrot.Infrastructure.Data;
using Peep.Parrot.Domain.ViewModels;

namespace Peep.Parrot.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly RedisDbConnection _redisDbConnection;

        public UserInfoRepository(RedisDbConnection redisDbConnection) 
        {
            this._redisDbConnection = redisDbConnection;
        }

        public bool AddUserInfo(AddUserInfoDto addUserInfoDto)
        {
            addUserInfoDto.IsPrivateAccount = false;
            return _redisDbConnection.CreateHash<AddUserInfoDto>($"user:{addUserInfoDto.Id}", addUserInfoDto);
        }

        public async Task<UserInfoViewModel> GetUserInfo(Guid id) =>
            await _redisDbConnection.GetObjectFromKey<UserInfoViewModel>($"user:{id}");

        public bool UpdateUserInfo(UpdateUserInfoDto updateUserInfoDto) =>
            _redisDbConnection.UpdateHashFromKey($"user:{updateUserInfoDto.Id}", updateUserInfoDto);

        public Task<bool> DeleteUserInfo(Guid id) =>
            _redisDbConnection.DeleteKey($"user:{id}");
    }
}
