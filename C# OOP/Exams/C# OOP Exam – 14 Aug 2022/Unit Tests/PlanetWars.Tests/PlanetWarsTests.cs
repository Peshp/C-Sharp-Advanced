using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponCounstructorShouldWorkProperly()
            {
                Weapon axe = new Weapon("w1", 10, 20);
                Assert.AreEqual("w1", axe.Name);
                Assert.AreEqual(10, axe.Price);
                Assert.AreEqual(20, axe.DestructionLevel);
            }
            [Test]
            public void NegativePriceShouldThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("w1", -10, 20));
            }
            [Test]
            public void IncreaseDestructionLevelShouldWorkProperly()
            {
                Weapon axe = new Weapon("w1", 10, 20);
                axe.IncreaseDestructionLevel();
                Assert.AreEqual(21, axe.DestructionLevel);
            }
            [Test]
            public void IsNuclearShouldWorkProperly()
            {
                Weapon axe = new Weapon("w1", 10, 20);
                Assert.AreEqual(true, axe.IsNuclear);
            }
            [Test]
            public void PlanetConstructorShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                Assert.AreEqual("p1", planet.Name);
                Assert.AreEqual(500, planet.Budget);
            }
            [Test]
            public void NullNameShouldThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() => new Planet("", 500));
            }
            [Test]
            public void NegativeBudgetShouldThrowsAnException()
            {
                Assert.Throws<ArgumentException>(() => new Planet("p1", -500));
            }
            [Test]
            public void ProfitShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.Profit(50);
                Assert.AreEqual(550, planet.Budget);
            }
            [Test]
            public void SpecndFundsShouldTrowsAnException()
            {
                Planet planet = new Planet("p1", 500);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(501));
            }
            [Test]
            public void SpecndFundsShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.SpendFunds(50);
                Assert.AreEqual(450, planet.Budget);
            }
            [Test]
            public void AddWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                Assert.AreEqual(1, planet.Weapons.Count);
            }
            [Test]
            public void AlreadyExistWeaponShouldThrowsAnException()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(new Weapon("w1", 11, 21)));
            }
            [Test]
            public void RemoveWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                planet.RemoveWeapon("w1");
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWeaponShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                Weapon axe = new Weapon("w1", 10, 20);
                planet.AddWeapon(axe);
                planet.UpgradeWeapon("w1");
                Assert.AreEqual(21, axe.DestructionLevel);
            }
            [Test]
            public void InvalidWeaponNameShouldThrowsAnException()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("w2"));
            }
            [Test]
            public void DestructorOpponentShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                planet.AddWeapon(new Weapon("w2", 5, 10));

                Planet planet2 = new Planet("p2", 400);
                planet2.AddWeapon(new Weapon("w1", 2, 2));
                planet2.AddWeapon(new Weapon("w2", 3, 1));
               
                string output = "p2 is destructed!";
                Assert.AreEqual(output, planet.DestructOpponent(planet2));
            }
            [Test]
            public void DestructionOpponentShouldTrowsAnException()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                planet.AddWeapon(new Weapon("w2", 5, 10));

                Planet planet2 = new Planet("p2", 400);
                planet2.AddWeapon(new Weapon("w1", 2, 2));
                planet2.AddWeapon(new Weapon("w2", 3, 1));

                Assert.Throws<InvalidOperationException>(() => planet2.DestructOpponent(planet));
            }
            [Test]
            public void MilitaryPowerRatioShouldWorkProperly()
            {
                Planet planet = new Planet("p1", 500);
                planet.AddWeapon(new Weapon("w1", 10, 20));
                planet.AddWeapon(new Weapon("w2", 5, 10));

                Assert.AreEqual(30, planet.MilitaryPowerRatio);
            }
        }
    }
}
