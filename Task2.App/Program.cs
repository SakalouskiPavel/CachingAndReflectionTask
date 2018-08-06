using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.App
{
    class Program
    {

        static void Main(string[] args)
        {
            CachingSystem cachingSystem = new CachingSystem();
            XmlParser<TaskEntity> parser = new XmlParser<TaskEntity>();
            TaskEntity firstEntity = new TaskEntity()
            {
                Id = 1,
                Name = "first entity"
            };
            TaskEntity secondEntity = new TaskEntity()
            {
                Id = 2,
                Name = "second entity"
            };
            TaskEntity thirdEntity = new TaskEntity()
            {
                Id = 3,
                Name = "third entity"
            };

            List<TaskEntity> entities = new List<TaskEntity>{firstEntity, secondEntity, thirdEntity};

            foreach (var entity in entities)
            {
                
                Console.WriteLine($"Serializing {entity.Name}");
                var xmlString = parser.Serialize(entity);
                Console.WriteLine($"Serialized : {xmlString} \n Saving to cache");
                cachingSystem.AddCache("key", xmlString);
                Console.WriteLine("Saved \n");
            }

            Console.WriteLine("Getting data from cache:");
            var data = cachingSystem.GetCache("key");
            var result = new List<TaskEntity>();

            foreach (var dataString in data)
            {
                Console.WriteLine(dataString);
                Console.WriteLine("Deserializing:");
                var entity = parser.Deserialize(dataString);
                result.Add(entity);
                Console.WriteLine(entity);
            }

            Console.ReadKey();
        }
    }
}
