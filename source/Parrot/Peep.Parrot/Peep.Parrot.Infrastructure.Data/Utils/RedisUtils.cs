using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using StackExchange.Redis;

namespace Peep.Parrot.Infrastructure.Data.Utils
{
    public static class RedisUtils
    {
        public static HashEntry[] ObjectToHashEntries(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            return properties
                .Where(x => x.GetValue(obj) != null)
                .Select
                (
                    property =>
                    {
                        object propertyValue = property.GetValue(obj);
                        string hashValue;

                        if (propertyValue is IEnumerable<object>)
                        {
                            hashValue = JsonSerializer.Serialize(propertyValue);
                        }
                        else
                        {
                            hashValue = propertyValue.ToString();
                        }

                        return new HashEntry(property.Name, hashValue);
                    }
                )
                .ToArray();
        }

        public static T HashEntriesToObject<T>(HashEntry[] hashEntries)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var obj = Activator.CreateInstance(typeof(T));

            foreach (var property in properties)
            {
                HashEntry entry = hashEntries.FirstOrDefault(he => he.Name.ToString().Equals(property.Name));
                if (entry.Equals(new HashEntry())) continue;

                if (property.PropertyType == typeof(Guid))
                {
                    property.SetValue(obj, Convert.ChangeType(Guid.Parse(entry.Value.ToString()), property.PropertyType));
                }
                else
                {
                    property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                }

            }
            return (T)obj;
        }

        public static RedisValue GuidToRedisValue(Guid guid) =>
           (RedisValue)guid.ToString();

        public static Guid RedisValueToGuid(RedisValue redisValue) =>
            Guid.Parse((string)redisValue);

        public static RedisValue[] GuidArrayToRedisValues(Guid[] guidArray)
        {
            if (guidArray == null || guidArray.Length == 0)
                return null;
            return Array.ConvertAll(guidArray, x => (RedisValue)x.ToString());

        }

        public static Guid[] RedisValuesToGuidArray(RedisValue[] redisValues)
        {
            if (redisValues == null || redisValues.Length == 0) 
                return null;
            return Array.ConvertAll(redisValues, x => Guid.Parse((string)x));
        }

    }
}
