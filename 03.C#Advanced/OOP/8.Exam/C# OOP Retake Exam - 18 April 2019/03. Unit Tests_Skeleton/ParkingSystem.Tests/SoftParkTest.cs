namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using ParkingSystem;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car testCar = new Car("Opel", "CA4567AA");
        private Dictionary<string, Car> testParking;

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
            testParking = new Dictionary<string, Car>
            {
                {"A2", null},
                {"A3", null}
            };
            softPark.ParkCar("A1", testCar);
        }


        [Test]
        public void TestFotCoutOfThePArkingPlaces()
        {
            Assert.
                AreEqual(12, softPark.Parking.Count);
        }

        [Test]
        public void ShoudThrowArgumentExeptionWhenTHeSpotIsNotExist()
        {
            Assert.Throws<ArgumentException>(() => softPark.ParkCar("Spot", testCar));
        }


        [Test]
        public void ShoudThrowArgumentExeptionWhenTheSpotIsAlreadyTaken()
        {
            Car car2 = new Car("Toyota", "8786");

            softPark.ParkCar("A2", car2);

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A2", car2));
        }

        [Test]
        public void ShoudParkSpotMethodWorkCorrectly()
        {
            Car car2 = new Car("Toyota", "8786");

            softPark.ParkCar("A2", car2);

            Assert.AreEqual(car2, softPark.Parking["A2"]);
        }

        [Test]
        public void ShowdRemuveCarParkigWorckCorrectly()
        {
            Car car2 = new Car("Toyota", "8786");

            softPark.ParkCar("A2", car2);
            softPark.RemoveCar("A2", car2);

            Assert.AreEqual(null, softPark.Parking["A2"]);
        }

        [Test]
        public void RemuveMethodShoudThrowExeptionWhenParkSpotDoesntExist()
        {
            Car car2 = new Car("Toyota", "8786");

            softPark.ParkCar("A2", car2);

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A5", car2));
        }

        [Test]
        public void RemuveMethodShoudThrowExeptionWhenTheCArDoesntExist()
        {
            Car car2 = new Car("Toyota", "8786");

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("A1", car2));
        }

        [Test]
        public void TestConstructorToCarWorckCorrectly()
        {
            Car car2 = new Car("Toyota", "8786");

            Assert.AreEqual("Toyota", car2.Make);
            Assert.AreEqual("8786", car2.RegistrationNumber);
        }
    }
}