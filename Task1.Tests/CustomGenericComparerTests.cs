using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomGenericComparerTests
    {
        private CustomGenericComparer<TestEntity> _comparer;
        private TestEntity _firstEqualEntity;
        private TestEntity _secondEqualEntity;
        private TestEntity _notEqualEntity;
        private InnerTestEntity _firstInnerEntity;
        private InnerTestEntity _secondInnerEntity;

        [SetUp]
        public void Initial()
        {
            this._comparer = new CustomGenericComparer<TestEntity>();
            this._firstInnerEntity = new InnerTestEntity()
            {
                Id = 1,
                Name = "inner entity"
            };
            this._secondInnerEntity = new InnerTestEntity()
            {
                Id = 1,
                Name = "inner entity"
            };
            this._firstEqualEntity = new TestEntity()
            {
                Id = 1,
                Name = "Equal entity",
                InnerEntity = this._firstInnerEntity
            };
            this._secondEqualEntity = new TestEntity()
            {
                Id = 1,
                Name = "Equal entity",
                InnerEntity = this._secondInnerEntity
            };
            this._notEqualEntity = new TestEntity()
            {
                Id = 2,
                Name = "Not equal entity",
                InnerEntity = this._secondInnerEntity
            };
        }

        [Test]
        public void ComparerEquals_TwoEqualEntities_EqualsTrue()
        {
            Assert.IsTrue(this._comparer.Equals(this._firstEqualEntity, this._secondEqualEntity));
        }

        [Test]
        public void ComparerEquals_TwoNotEqualEntities_EqualsFalse()
        {
            Assert.IsFalse(this._comparer.Equals(this._firstEqualEntity, this._notEqualEntity));
        }

        [Test]
        public void ComparerEquals_OneOfEntitiesNull_EqualsFalse()
        {
            Assert.IsFalse(this._comparer.Equals(this._firstEqualEntity, null));
            Assert.IsFalse(this._comparer.Equals(null, this._notEqualEntity));

        }

        [Test]
        public void ComparerEquals_InnerEntitiesNotEqual_EqualsFalse()
        {
            this._secondEqualEntity.InnerEntity.Id = 2;
            Assert.IsFalse(this._comparer.Equals(this._firstEqualEntity, this._secondEqualEntity));
        }

        [Test]
        public void ComparerEquals_OneOfInnerEntitiesNull_EqualsFalse()
        {
            this._secondEqualEntity.InnerEntity = null;
            Assert.IsFalse(this._comparer.Equals(this._firstEqualEntity, this._secondEqualEntity));
        }
    }
}