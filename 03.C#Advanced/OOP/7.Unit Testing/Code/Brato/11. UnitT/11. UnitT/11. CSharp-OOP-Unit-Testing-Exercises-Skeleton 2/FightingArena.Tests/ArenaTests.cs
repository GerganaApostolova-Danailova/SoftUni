//using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Stamat", 10, 100);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(0, arena.Warriors.Count);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestEnrollNewWarrior()
        {
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Warriors.Count);
        }

        [Test]
        public void TestEnrollSameWarrior()
        {
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFight()
        {
            Warrior attacker = new Warrior("Stamat", 10, 100);
            Warrior defender = new Warrior("Gosho", 10, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Stamat", "Gosho");

            Assert.AreEqual(90, attacker.HP);
            Assert.AreEqual(90, defender.HP);
        }

        [Test]
        public void TestFight2Nulls()
        {
            Assert.That(() => arena.Fight("Stamat", "Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFightAttackerNull()
        {
            Warrior defender = new Warrior("Gosho", 10, 100);
            arena.Enroll(defender);

            Assert.That(() => arena.Fight("Stamat", "Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestFightDefenderNull()
        {
            Warrior attacker = new Warrior("Stamat", 10, 100);

            arena.Enroll(attacker);

            Assert.That(() => arena.Fight("Stamat", "Gosho"), Throws.InvalidOperationException);
        }
    }
}
