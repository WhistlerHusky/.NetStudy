using NetStudy.Core;
using Newtonsoft.Json;
using System;

namespace Redis
{
    public class RedisRunner : IRunner
    {
        int _devicesCount = 100;

        public void Run()
        {
            Console.WriteLine("Saving TestEntity data in cache");
            SaveBigTestEntityData();

            Console.WriteLine("Reading TestEntity from cache");
            ReadTestEntityData();
        }

        public void ReadTestEntityData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 0; i < _devicesCount; i++)
            {
                var value = cache.StringGet($"TestEntity:{i}");
                if (value.IsNull == false)
                {
                    var serializedObject = JsonConvert.DeserializeObject<TestEntity>(value);
                    Console.WriteLine($"Id : {serializedObject.Id} Name : {serializedObject.TestName}");
                }
                else
                {
                    Console.WriteLine($"Key : TestEntity:{i} not found");
                }
            }
        }

        public void SaveBigTestEntityData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();

            for (int i = 0; i < _devicesCount; i++)
            {
                var testEntity = new TestEntity
                {
                    Id = i,
                    TestName = $"Test {i}"
                };

                var valueExists = cache.StringGet($"TestEntity:{i}");
                if (valueExists.IsNull)
                {
                    var serializedObject = JsonConvert.SerializeObject(testEntity);
                    cache.StringSet($"TestEntity:{i}", serializedObject);
                }
            }
        }
    }
}
