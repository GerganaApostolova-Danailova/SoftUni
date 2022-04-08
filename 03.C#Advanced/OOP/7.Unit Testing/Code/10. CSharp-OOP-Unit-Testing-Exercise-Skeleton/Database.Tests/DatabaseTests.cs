using NUnit.Framework;

namespace Tests
{
    using Database;
    using System;

    public class DatabaseTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShoudBeInitializeWhith16Elements()
        {
            int[] array = new int[16];

            Database database = new Database(array);

            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShoudThrowInvalidOperationExeptin()
        {
            int[] array = new int[17];

            Assert.
                Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void AddMethodShoudAddCorectly()
        {
            Database database = new Database();

            database.Add(1);

            int expectedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShoudAddOnTHeNextEmptyIndex()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);

            database.Add(6);

            int expectedCount = 6;
            int actualCount = database.Fetch()[5];

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExeptionWhenElementsAreExeeded()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            Assert
                .Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void ShoudRemuveCorectlyAndDegriceCount()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);

            database.Remove();
            int expectedCount = 2;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void ShoudRemuveCorectlyLastElement()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);

            database.Remove();

            int expectedVAlue = 2;
            int actualVAlue = database.Fetch()[database.Count - 1];

            Assert.AreEqual(expectedVAlue, actualVAlue);

        }

        [Test]
        public void RemuveMethodShouldThrowInvalidOperationExeption()
        {
            Database database = new Database();

            Assert.
                Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShoudReturnAllElementAsAnArray()
        {
            int[] array = { 1,5,2,4,5 };
            Database database = new Database(array);

            
            int[] expectedVAlue = { 1, 5, 2, 4, 5 };
            int []actualVAlue = database.Fetch();

            Assert.AreEqual(expectedVAlue, actualVAlue);

            CollectionAssert.AreEqual(expectedVAlue, actualVAlue);
        }


    }
}