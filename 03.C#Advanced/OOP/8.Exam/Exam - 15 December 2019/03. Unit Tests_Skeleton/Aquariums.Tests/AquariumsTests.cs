namespace Aquariums.Tests
{
    using System;
    using Aquariums;
    using NUnit.Framework;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            aquarium = new Aquarium("Nemo", 20);
            fish = new Fish("Ribka");
        }

        [Test]
        public void TestConstructorOfFishWorkCorrectly()
        {
            Fish fish2 = new Fish("Gosho");
            bool isAvaiable = true;

            Assert.AreEqual("Gosho", fish2.Name);
            Assert.AreEqual(isAvaiable, fish2.Available);
        }

        [Test]
        public void TestConstructorOfAquariumWorkCorrectly()
        {
            Assert.AreEqual("Nemo", aquarium.Name);
            Assert.AreEqual(20, aquarium.Capacity);
        }

        [Test]
        public void TestNameNotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium("", 50));
        }

        [Test]
        public void TestCapacityNotBeBelowZero()
        {
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Nemo", -1));
        }

        [Test]
        public void TestAddMethodWorkCorrectly()
        {
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void AddMethodThrowExeptionWhenCapacityIsFull()
        {
            Aquarium aquarium2 = new Aquarium("Glass", 2);

            Fish fish2 = new Fish("Penka");
            Fish fish3 = new Fish("Genka");
            Fish fish4 = new Fish("Fifo");

            aquarium2.Add(fish2);
            aquarium2.Add(fish3);

            Assert.Throws<InvalidOperationException>(() => aquarium2.Add(fish4));
        }

        //public void RemoveFish(string name)
        //{
        //    Fish fishToRemove = this.fish.FirstOrDefault(x => x.Name == name);

        //    if (fishToRemove == null)
        //    {
        //        throw new InvalidOperationException($"Fish with the name {name} doesn't exist!");
        //    }

        //    this.fish.Remove(fishToRemove);
        //}

        [Test]
        public void RemuveMethodShoudWorkCorrectly()
        {
            //aquarium = new Aquarium("Nemo", 20);
            //fish = new Fish("Ribka");

            string name = "Ribka";

            aquarium.Add(fish);

            Assert.AreEqual(, aquarium.RemoveFish(name));
        }

        [Test]
        public void TestRemuveMethodDontWork()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Gencho"));
        }

        [Test]
        public void SellFishMethodWorkCorrectly()
        {
            aquarium.Add(fish);

            Assert.AreEqual(fish, aquarium.SellFish("Ribka"));
        }

        [Test]
        public void SellFishMethodDontWork()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gosho"));
        }

        [Test]
        public void TestReportMethodWorkCorrectly()
        {
            Fish fish2 = new Fish("Alex");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            string report = "Fish available at Nemo: Ribka, Alex";

            Assert.AreEqual(report, aquarium.Report());
        }
    }
}
