using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AxeLooseDurabilityAfterAttack()
        {

            Axe axe = new Axe(10, 10);

            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 9);

        }

        [Test]
        public void TestAttackWithBrokenWeapon()
        {
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(20, 20);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}