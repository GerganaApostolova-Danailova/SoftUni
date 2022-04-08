namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;
    //using BlueOrigin;
    using System.Collections.Generic;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void TestConstructor()
        {
            spaceship = new Spaceship("Rocket", 2);
            Assert.AreEqual("Rocket", spaceship.Name);
            Assert.AreEqual(2, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void ShoudSpaceshipConstructorWorkCorrectly()
        {
            spaceship = new Spaceship("Voiadgar", 50);

            Assert.AreEqual("Voiadgar", spaceship.Name);
            Assert.AreEqual(50, spaceship.Capacity);
        }

        [Test]
        public void ShoudAstronautpConstructorWorkCorrectly()
        {
            Astronaut astronaut = new Astronaut("Gosho", 10.0);

            Assert.AreEqual("Gosho", astronaut.Name);
            Assert.AreEqual(10.0, astronaut.OxygenInPercentage);
        }

        [Test]
        public void ShoudSpaceshipMethodThrowExeptionWhenNameAreNull()
        {
            Assert.Throws<ArgumentNullException>(() => spaceship = new Spaceship("", 50));
        }

        [Test]
        public void ShoudSpaceshipMethodThrowExeptionWhenCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() => spaceship = new Spaceship("Gosho", -50));
        }

        [Test]
        public void ShoudAddMethodWorkCorrectly()
        {
            Astronaut astronaut = new Astronaut("Gosho", 10.0);
            spaceship = new Spaceship("Voiadgar", 50);

            spaceship.Add(astronaut);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void TestAddSameAstro()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship.Add(astro);

            Assert.That(() => spaceship.Add(astro), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShoudThrowExeptionWhneCapacityIsFull()
        {
            spaceship = new Spaceship("Voiadgar", 2);

            Astronaut astronaut = new Astronaut("Gosho", 10.0);
            spaceship.Add(astronaut);

            Astronaut astronaut2 = new Astronaut("Pena", 20.0);
            spaceship.Add(astronaut2);

            Astronaut astronaut3 = new Astronaut("Gena", 50.0);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut3));
        }

        [Test]
        public void RemuveMethodShoudWorckCorrectly()
        {
            Astronaut astronaut = new Astronaut("Pesho", 30.0);

            spaceship = new Spaceship("Suvalka", 2);

            spaceship.Add(astronaut);

            Assert.AreEqual(true, spaceship.Remove("Pesho"));
        }

        [Test]
        public void TestRemoveNonExistingAstro()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship = new Spaceship("Suvalka", 2);

            spaceship.Add(astro);

            Assert.AreEqual(false, spaceship.Remove("Gosho2"));
        }


    }
}