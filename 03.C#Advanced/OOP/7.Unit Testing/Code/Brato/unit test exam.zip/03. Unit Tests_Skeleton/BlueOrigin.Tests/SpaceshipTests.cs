namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void Setup()
        {
            spaceship = new Spaceship("Rocket", 2);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Rocket", spaceship.Name);
            Assert.AreEqual(2, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void TestInvalidName()
        {
            Spaceship spaceship2;

            Assert.That(() => spaceship2 = new Spaceship(null, 11), Throws.ArgumentNullException);
        }

        [Test]
        public void TestInvalidCapacity()
        {
            Spaceship spaceship2;

            Assert.That(() => spaceship2 = new Spaceship("Raketa", -5), Throws.ArgumentException);
        }

        [Test]
        public void TestAddAstronaut()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);

            spaceship.Add(astro);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void TestAddCapacity()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship.Add(astro);

            Astronaut astro2 = new Astronaut("Gosho2", 90.0);
            spaceship.Add(astro2);

            Astronaut astro3 = new Astronaut("Gosho3", 100.0);

            Assert.That(() => spaceship.Add(astro3), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddSameAstro()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship.Add(astro);

            Assert.That(() => spaceship.Add(astro), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveAstro()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship.Add(astro);

            Assert.AreEqual(true, spaceship.Remove("Gosho"));
        }

        [Test]
        public void TestRemoveNonExistingAstro()
        {
            Astronaut astro = new Astronaut("Gosho", 80.0);
            spaceship.Add(astro);

            Assert.AreEqual(false, spaceship.Remove("Gosho2"));
        }
    }
}