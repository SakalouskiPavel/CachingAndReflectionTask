using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class CachingSystemTests
    {
        private CachingSystem _cachingSystem;
        private TaskEntity _testEntity;
        private XmlParser<TaskEntity> _parser;

        [SetUp]
        public void Initial()
        {
            this._testEntity = new TaskEntity()
            {
                Id = 1,
                Name = "Name"
            };
            this._cachingSystem = new CachingSystem();
            this._parser = new XmlParser<TaskEntity>();
        }

        [Test]
        public void AddCacheTest()
        {
            var str = this._parser.Serialize(this._testEntity);
            this._cachingSystem.AddCache(str);
        }

        [Test]
        public void GetCacheTest()
        {
            var str = this._parser.Serialize(_testEntity);
            var cache = this._cachingSystem.GetCache("key");
        }


    }
}