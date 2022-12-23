using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;
        [Test]
        public void ConstructorShouldWorkProperlyWithCapacity()
        {
            gym = new Gym("Name", 10);
            Assert.AreEqual(gym.Capacity, 10);
        }
        [Test]
        public void ConstructorShouldWorkProperlyWithName()
        {
            gym = new Gym("Name", 10);
            Assert.AreEqual(gym.Name, "Name");
        }
        [Test]
        public void NamePropertyShouldThrowsAnExceptionWhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 10));
        }
        [Test]
        public void CapacityPropertyShouldThrowsAnExceptionWhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Gym("g1", -1));
        }
        [Test]
        public void CountShouldWorkProperlyWithAddAthlete()
        {
            gym = new Gym("g1", 2);
            gym.AddAthlete(new Athlete("a1"));
            Assert.AreEqual(gym.Count, 1);
        }
        [Test]
        public void AddAthleteShouldThrowsAnExceptionWhenGymIsFull()
        {
            gym = new Gym("g1", 2);
            gym.AddAthlete(new Athlete("a1"));
            gym.AddAthlete(new Athlete("a2"));
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("a3")));
        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            gym = new Gym("g1", 2);
            gym.AddAthlete(new Athlete("a1"));
            gym.AddAthlete(new Athlete("a2"));
            gym.RemoveAthlete("a1");
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void RemoveShouldThrowsAnExceptionWhenNameIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => new Gym("g1", 2).RemoveAthlete(null));
        }
        [Test]
        public void InjureAthleteShouldWorkProperly()
        {
            gym = new Gym("g1", 2);
            Athlete a1 = new Athlete("a1");
            gym.AddAthlete(a1);           
            Assert.AreEqual(a1, gym.InjureAthlete("a1"));
        }
        [Test]
        public void InjureAthleteShouldThrowsAnExceptionWhenAthleteIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => new Gym("g1", 2).InjureAthlete(null));
        }
        [Test]
        public void ReportShouldWorkProperly()
        {
            gym = new Gym("g1", 2);
            gym.AddAthlete(new Athlete("a1"));
            gym.AddAthlete(new Athlete("a2"));
            string output = $"Active athletes at g1: a1, a2";
            Assert.AreEqual(output, gym.Report());
        }
    }
}
