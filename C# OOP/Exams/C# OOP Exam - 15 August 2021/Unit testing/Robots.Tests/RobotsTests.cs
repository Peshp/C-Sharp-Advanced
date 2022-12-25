namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectlyWithCapacity()
        {
            var robots = new RobotManager(4);
            Assert.AreEqual(4, robots.Capacity);
        }
        [Test]
        public void NegativeCapacityShouldThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-4));
        }
        [Test]
        public void EmptyCountShouldhaveCountToZero()
        {
            var robots = new RobotManager(4);
            Assert.AreEqual(0, robots.Count);
        }
        [Test]
        public void CountShouldWorkCorrectly()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Add(new Robot("r3", 100));
            Assert.AreEqual(3, robots.Count);
        }
        [Test]
        public void AddMethodShouldThrowsAnExceptioWhenNameIsAlreadyExist()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("r2", 100)));
        }
        [Test]
        public void AddMethodShouldThrowsAnExceptionWhenIsNotEnoughCapacity()
        {
            var robots = new RobotManager(1);
            robots.Add(new Robot("r1", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("r2", 100)));
        }
        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Remove("r2");
            Assert.AreEqual(robots.Count, 1);
        }
        [Test]
        public void RemoveMethodShoudThrowsAnExceptinoWhenRobotIsNotFound()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Remove("r3"));
        }
        [Test]
        public void WorkMethodShouldWorkCorrectly()
        {
            var robots = new RobotManager(4);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            robots.Work("r1", "...", 60);
            Assert.AreEqual(robot.Battery, 40);
        }
        [Test]
        public void WorkMethodShouldThrowsAnExceptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(4);    
            robots.Add(new Robot("r1", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Work("r2", "...", 60));
        }
        [Test]
        public void WorkMethodShouldThrowsAndExceptionWhenIsNotEnoughBattery()
        {
            var robots = new RobotManager(4);
            robots.Add(new Robot("r1", 40));
            Assert.Throws<InvalidOperationException>(() => robots.Work("r1", "...", 60));
        }
        [Test]
        public void ChargeShouldWorkCorrectly()
        {
            var robots = new RobotManager(4);
            var robot = new Robot("r1", 40);
            robots.Add(robot);
            robots.Work("r1", "...", 20);
            robots.Charge("r1");
            Assert.AreEqual(robot.Battery, 40);
        }
        [Test]
        public void ChargeShouldThrowsAndExceptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(4);          
            robots.Add(new Robot("r1", 40));
            robots.Work("r1", "...", 20);
            Assert.Throws<InvalidOperationException>(() => robots.Charge("r2"));
        }
    }
}
