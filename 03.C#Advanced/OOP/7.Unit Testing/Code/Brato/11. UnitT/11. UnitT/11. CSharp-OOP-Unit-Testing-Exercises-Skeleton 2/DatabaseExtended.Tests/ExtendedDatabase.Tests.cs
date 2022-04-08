using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const long ID = 123;
        private const string USERNAME = "Gosho";

        private ExtendedDatabase.ExtendedDatabase database;
        private ExtendedDatabase.Person person;

        private ExtendedDatabase.Person[] data = new ExtendedDatabase.Person[] 
        {
            new ExtendedDatabase.Person(ID, USERNAME)
        };

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase(data);
            person = new ExtendedDatabase.Person(456, "Ivo");
        }

        [Test]
        public void TestConstructor()
        {
            Setup();
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void TestAddElement()
        {
            database.Add(person);

            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void TestFullDatabase()
        {
            for (int i = 2; i <= 16; i++)
            {
                database.Add(new ExtendedDatabase.Person(123, "Stamat"));
            }

            Assert.That(() => database.Add(new ExtendedDatabase.Person(123, "Kolio")), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveElemnt()
        {
            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]
        public void TestRemoveFromEmptyDatabase()
        {
            int count = database.Count;

            for (int i = 0; i < 1; i++)
            {
                database.Remove();
            }

            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }



        
    }
}