using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Peep.Parrot.Infrastructure.Data.Utils;

namespace Peep.Parrot.Infrastructure.Data
{
    public class RedisDbConnection
    {
        private readonly IConfiguration _config;
        protected readonly ConnectionMultiplexer _connection;

        public RedisDbConnection(IConfiguration config)
        {
            this._config = config;
            this._connection = ConnectionMultiplexer.Connect(_config.GetConnectionString("redis"));
        }

        protected bool Disconnect()
        {
            if (_connection.IsConnected)
                return  _connection.CloseAsync().IsCompletedSuccessfully;
            return false;
        }

        protected async Task<T> GetObjectFromKey<T>(string key)
        {
            var db = _connection.GetDatabase();
            var redisHash = await db.HashGetAllAsync(key);
            var obj = RedisUtils.HashEntriesToObject<T>(redisHash);
            return obj;
        }

        protected bool CreateHash<T>(string key, T obj)
        {
            var db = _connection.GetDatabase();
            var hash = RedisUtils.ObjectToHashEntries(obj);

            if (!db.KeyExists(key))
                return db.HashSetAsync(key, hash).IsCompletedSuccessfully;
            return false;
            
        }

        protected bool UpdateHashFromKey<T>(string key, T obj)
        {
            var db = _connection.GetDatabase();
            var hash = RedisUtils.ObjectToHashEntries(obj);

            if (db.KeyExists(key))
                return db.HashSetAsync(key, hash).IsCompletedSuccessfully;
            return false;
        }

        protected void AddGuidToListHead(string listKey, Guid guid)
        {
            var db = _connection.GetDatabase();
            db.ListLeftPushAsync(listKey, RedisUtils.GuidToRedisValue(guid));
        }

        protected void AddGuidToListTail(string listKey, Guid guid)
        {
            var db = _connection.GetDatabase();
            db.ListRightPushAsync(listKey, RedisUtils.GuidToRedisValue(guid));
        }

        protected void AddGuidArrayToListHead(string listKey, Guid[] guidArray)
        {
            var db = _connection.GetDatabase();
            db.ListLeftPushAsync(listKey, RedisUtils.GuidArrayToRedisValues(guidArray));
        }

        protected void AddGuidArrayToListTail(string listKey, Guid[] guidArray)
        {
            var db = _connection.GetDatabase();
            db.ListRightPushAsync(listKey, RedisUtils.GuidArrayToRedisValues(guidArray));
        }

        protected async Task<bool> DeleteKey(string key)
        {
            var db = _connection.GetDatabase();
            return await db.KeyDeleteAsync(key);
        }
           
    }
}
