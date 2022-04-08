using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Ferarri", "California", 25.0, 100.0);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Ferarri", car.Make);
            Assert.AreEqual("California", car.Model);
            Assert.AreEqual(25.5, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        public void TestDefoltFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void TestMakeNullOrEmpty()
        {
            Car car2;

            Assert.That(() => car2 = new Car(null, "California", 25.5, 100.0), Throws.ArgumentException);
        }

        [Test]
        public void TestModelNullOrEmpty()
        {
            Car car2;

            Assert.That(() => car2 = new Car("Ferarri", null, 25.5, 100.0), Throws.ArgumentException);
        }

        [Test]
        public void TestFuelConsuptionIsNegativeOrZero()
        {
            Car car2;

            Assert.That(() => car2 = new Car("Ferarri", "California", -1, 100.0), Throws.ArgumentException);
            Assert.That(() => car2 = new Car("Ferarri", "California", 0, 100.0), Throws.ArgumentException);
        }

        [Test]
        public void TestFuelCapacityIsNegativeOrZero()
        {
            Car car2;

            Assert.That(() => car2 = new Car("Ferarri", "California", 25, -1), Throws.ArgumentException);
            Assert.That(() => car2 = new Car("Ferarri", "California", 25, 0), Throws.ArgumentException);
        }

        [Test]
        public void TestAmount()
        {
            car.Refuel(50);

            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        public void TestAmountLessThanZero()
        {
            Assert.That(() => car.Refuel(-50), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be negative!"));
        }

        [Test]
        public void TestRefuelAmountMoreThanCapaciti()
        {
            car.Refuel(120);

            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]
        public void TestRefuelLessOrEqualsToZero()
        {
            Assert.That(() => car.Refuel(-50), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
            Assert.That(() => car.Refuel(0), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void TestDriveLessDistance()
        {
            car.Refuel(100);
            car.Drive(100);

            double expectedFuelAmount = 75.0;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestDriveMoreDistance()
        {
            car.Refuel(24);

            Assert.That(() => car.Drive(100), Throws.InvalidOperationException);
        }
    }
}