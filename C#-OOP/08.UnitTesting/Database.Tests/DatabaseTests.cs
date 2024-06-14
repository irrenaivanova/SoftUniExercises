namespace Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Database;

    [TestFixture]
    public class DatabaseTests
    {
        private Database defDb;

        [SetUp]
        public void SetUp()
        {
            defDb = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
        {
            var dataBase = new Database(data);
            Assert.AreEqual(data.Length, dataBase.Count);
        }

        [Test]
        public void When_CreatingData_ShouldThrowExecption_When_InputData_IsAbove16()
        {
            int[] data = new int[17];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            Assert.Throws<InvalidOperationException>(() => { new Database(data); });
        }


        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_ShouldAddElements_InTheArray(int[] data)
        {
            Database db = new Database(data);
            int[] expected = data;
            int[] actual = db.Fetch();
            CollectionAssert.AreEqual(expected, actual);
        }
        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            int expectedCount = 5;
            for (int i = 0; i < expectedCount; i++)
            {
                defDb.Add(i);
            }

            Assert.AreEqual(expectedCount, defDb.Count);
        }


        public void AddingElementsShouldAddThemToTheCollection()
        {
            int[] expectedData = new int[5];
            for (int i = 0; i < 5; i++)
            {
                defDb.Add(i);
                expectedData[i] = i;
            }
            CollectionAssert.AreEqual(expectedData, defDb.Fetch());
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void When_AddingAnElement_ShouldThrowException_IfCapacityIsFull(int[] data)
        {
            defDb = new Database(data);
            Assert.Throws<InvalidOperationException>(() => { defDb.Add(5); });
        }

        [Test]
        public void When_RemovingAnElementFromEmptyDB_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => { defDb.Remove(); });
        }


        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemovingElementsShouldDecreaseCount(int[] data)
        {
            defDb = new Database(data);
            defDb.Remove();
            Assert.AreEqual(data.Length - 1, defDb.Count);
        }
    }

}
