using NUnit.Framework;
//using Database;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private int[] data = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
             database = new Database(data);
        }

        [Test]
        public void TestConstructor()
        {
            Setup();
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void TestAddElement()
        {
            database.Add(3);

            Assert.AreEqual(3, database.Count);
        }

        [Test]
        public void TestFullDatabase()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.That(() => database.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveElemnt()
        {
            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void TestRemoveFromEmptyDatabase()
        {
            int count = database.Count;

            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFetch()
        {
            CollectionAssert.AreEqual(database.Fetch(), data);
        }


    }
}