using NUnit.Framework;

namespace Tests
{
    //using CarManager;
    using System;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShowdInitializeCorectly()
        {
            //string make, string model, double fuelConsumption, double fuelCapacity
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        //[Test]
        //public void MakeShowdThrowArgumentExeptionWhenIsNull()
        //{
        //    //string make, string model, double fuelConsumption, double fuelCapacity
        //    string make = null;
        //    string model = "Golf";
        //    double fuelConsumption = 2;
        //    double fuelCapacity = 100;

        //    Assert
        //         .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        //}

        [Test]
        [TestCase(null, "Golf", 2, 100)]
        [TestCase("VW", null, 2, 100)]
        [TestCase("VW", "Golf", 0, 100)]
        [TestCase("VW", "Golf", -10, 100)]
        [TestCase("VW", "Golf", 2, 0)]
        [TestCase("VW", "Golf", 2, -100)]

        public void AllPropertiesShowdThowArgumentExeptions(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert
                 .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void SowdRefuleNormaly()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);

            double expectedFuelAmpount = 10;
            double actualFuelAmount = car.FuelAmount; 

            Assert.AreEqual(expectedFuelAmpount,actualFuelAmount);
        }

        [Test]
        public void SowdRefuleUntilTotalFuelCapacity()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(150);

            double expectedFuelAmpount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmpount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void RefuleShoudTrowArgunentExeptionWhenFuelAmountIsBelowZero
            (double inputAmount)
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                 .Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        
        public void ShoudDriveNormaly()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmpount = 19.6;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmpount, actualFuelAmount);
        }

        [Test]

        public void DriveShoudThrowInvalidOperationExeptionWhenFuelAmountIsNotEnaf()
        {
            string make = "Vw";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                 .Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}