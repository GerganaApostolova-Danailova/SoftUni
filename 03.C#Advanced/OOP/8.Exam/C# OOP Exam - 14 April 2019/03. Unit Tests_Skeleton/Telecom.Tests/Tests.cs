namespace Telecom.Tests
{
    using NUnit.Framework;
    //using Telecom;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            phone = new Phone("Make", "Model");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
        }

        [Test]
        public void TestMAkeAreCorectlyName()
        {
            Assert.AreEqual("Make", this.phone.Make);
        }

        [Test]
        public void TestMAkeShoudThrowExeptionWhenIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "Model"));
        }

        [Test]
        public void TestModelAreCorectlyName()
        {
            Assert.AreEqual("Model", this.phone.Model);
        }

        [Test]
        public void TestModelShoudThrowExeptionWhenIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Make", ""));
        }

        [Test]
        public void TestCount()
        {
            phone.AddContact("Geri", "1233");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddWorkingCorrectly()
        {
            phone.AddContact("Geri", "1233");
            phone.AddContact("Niki", "1433");

            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void AddShouldThrowExeptionWhenAddExixstingName()
        {
            phone.AddContact("Geri", "1233");
            Assert
                .Throws<InvalidOperationException>(() => phone.AddContact("Geri", "1233"));
        }

        [Test]
        public void CallMethodShoudWorkCorrectly()
        {
            string output = "Calling Kiki - 45678...";

            phone.AddContact("Kiki", "45678");

            Assert.AreEqual(output, phone.Call("Kiki"));
        }

        [Test]
        public void CallMethodShoudThrowExeptionWhenNameDoneNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("Geri"));
        }
    }
}