using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using StackExchange.Redis;

namespace Task2
{
    public class CachingSystem
    {
        
        public void AddCache(string key, string value)
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();
                db.SetAdd(key, value);
            }
        }

        public string[] GetCache(string key)
        {
            string[] result;
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                var db = redis.GetDatabase();
                result = db.SetMembers(key).Select(value => value.ToString()).ToArray();
            }

            return result;
        }
    }
}