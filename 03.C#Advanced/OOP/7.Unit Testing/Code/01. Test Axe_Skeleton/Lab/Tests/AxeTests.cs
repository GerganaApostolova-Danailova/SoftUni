using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class AxeTests
    {
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10,10);

            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9));
           
        }

        [Test]
        public void TestAttackWithBrocenAxe()
        {
            Axe axe = new Axe(10, 1);

            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);            

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
