using NUnit.Framework;
using System;
using System.Linq;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle unitMotorcycle;
        private UnitRider unitRider;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            unitMotorcycle = new UnitMotorcycle("Toyota", 87, 1.3);
            unitRider = new UnitRider("Gosho", unitMotorcycle);
            raceEntry = new RaceEntry();
        }
        [Test]
        public void UnitMotorcycleConstructorShowdWorkCorrectly()
        {
            Assert.AreEqual("Toyota", unitMotorcycle.Model);
            Assert.AreEqual(87, unitMotorcycle.HorsePower);
            Assert.AreEqual(1.3, unitMotorcycle.CubicCentimeters);
        }

        [Test]
        public void ShowdConstructorOfUnitRiderWorkCorrectly()
        {
            Assert.AreEqual("Gosho", unitRider.Name);
        }

        [Test]
        public void TestSwoudThrowExeptionWhenNameOfUniteRiderIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, unitMotorcycle));
        }

        [Test]
        public void TestAddMethodShowdWorkCorrectly()
        {
            string output = "Rider Gosho added in race.";

            Assert.AreEqual(output, raceEntry.AddRider(unitRider));
        }

        [Test]
        public void AddMethodShoudHaveExeptionWhenRiderIsNull()
        {
            UnitRider rider2 = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider2));
        }

        [Test]
        public void AddMethodShoudHaveExeptionWhenRiderNameAreAlreadyExist()
        {
            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(unitRider));
        }

        [Test]
        public void TestTHeCountOfRiders()
        {
            raceEntry.AddRider(unitRider);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void TestCalculateHPAverageWorkCorrectly()
        {
            var unitMotorcycle2 = new UnitMotorcycle("Trabant", 87, 1.3);
            var unitRider2 = new UnitRider("Geri", unitMotorcycle2);
            raceEntry.AddRider(unitRider);
            raceEntry.AddRider(unitRider2);

            Assert.AreEqual(87, raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateHPAverageThrowExeption()
        {
            
            raceEntry.AddRider(unitRider);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

    }
}