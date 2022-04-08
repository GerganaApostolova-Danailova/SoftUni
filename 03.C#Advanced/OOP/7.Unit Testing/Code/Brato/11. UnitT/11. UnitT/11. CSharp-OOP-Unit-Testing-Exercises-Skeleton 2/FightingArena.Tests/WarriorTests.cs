using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Gosho", 10, 100);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Gosho", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void TestNameNull()
        {
            Warrior warrior2;

            Assert.That(() => warrior2 = new Warrior(null, 10, 100), Throws.ArgumentException);
        }

        [Test]
        public void TestDamageNotPositive()
        {
            Warrior warrior2;

            Assert.That(() => warrior2 = new Warrior("Stamat", -10, 100), Throws.ArgumentException);
            Assert.That(() => warrior2 = new Warrior("Stamat", 0, 100), Throws.ArgumentException);
        }

        [Test]
        public void TestHPNotPositive()
        {
            Warrior warrior2;

            Assert.That(() => warrior2 = new Warrior("Stamat", 10, -100), Throws.ArgumentException);
        }

        [Test]
        public void TestAttackMoreHPBoth()
        {
            Warrior warrior2 = new Warrior("Stamat", 10, 100);

            warrior.Attack(warrior2);

            Assert.AreEqual(90, warrior.HP);
        }

        [Test]
        public void TestAttackMoreHPBoth2()
        {
            Warrior warrior2 = new Warrior("Stamat", 10, 100);

            warrior.Attack(warrior2);

            Assert.AreEqual(90, warrior2.HP);
        }

        [Test]
        public void TestAttackMoreHPBoth3()
        {
            Warrior warrior1 = new Warrior("Stamat", 101, 100);
            Warrior warrior2 = new Warrior("Stamat", 10, 100);

            warrior1.Attack(warrior2);

            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void TestAttackHPW1LessMin()
        {
            Warrior warrior1 = new Warrior("Stamat", 101, 29);
            Warrior warrior2 = new Warrior("Stamat", 10, 100);

            Assert.That(() => warrior1.Attack(warrior2),
                Throws.InvalidOperationException.With.Message.
                EqualTo("Your HP is too low in order to attack other warriors!"));

            Warrior warrior3 = new Warrior("Stamat", 101, 30);
            Warrior warrior4 = new Warrior("Stamat", 10, 100);

            Assert.That(() => warrior3.Attack(warrior4),
                Throws.InvalidOperationException.With.Message.
                EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void TestAttackHPW2LessMin()
        {
            Warrior warrior1 = new Warrior("Stamat", 101, 100);
            Warrior warrior2 = new Warrior("Stamat", 10, 29);

            Assert.That(() => warrior1.Attack(warrior2),
                Throws.InvalidOperationException);

            Warrior warrior3 = new Warrior("Stamat", 101, 100);
            Warrior warrior4 = new Warrior("Stamat", 10, 30);

            Assert.That(() => warrior3.Attack(warrior4),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestAttackStrongerWarrior()
        {
            Warrior warrior1 = new Warrior("Stamat", 10, 100);
            Warrior warrior2 = new Warrior("Stamat", 101, 29);

            Assert.That(() => warrior1.Attack(warrior2), Throws.InvalidOperationException);
        }
    }
}