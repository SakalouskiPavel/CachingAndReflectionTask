using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class XmlParserTests
    {
        private TaskEntity _entity;

        private XmlParser<TaskEntity> _parser;

        [SetUp]
        public void Initial()
        {
            this._parser = new XmlParser<TaskEntity>();
            this._entity = new TaskEntity()
            {
                Id = 1,
                Name = "Name"
            };
        }

        [Test]
        public void SerializeTest()
        {
            var str = _parser.Serialize(this._entity);
        }

        [Test]
        public void DeserializeTest()
        {
            var str = _parser.Serialize(this._entity);
            var resultObj = this._parser.Deserialize(str);
            Assert.AreEqual(this._entity.Id, resultObj.Id);
            Assert.AreEqual(this._entity.Name, resultObj.Name);
        }
    }
}