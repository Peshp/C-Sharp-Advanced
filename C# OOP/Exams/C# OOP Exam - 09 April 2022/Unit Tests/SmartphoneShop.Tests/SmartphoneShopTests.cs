using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {       
        [Test]
        public void ConstructorShouldWorkProperlyWithCapacity()
        {
            Shop shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);
        }      
        [Test]
        public void InvalidCapacityPropertyShouldThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-5));
        }
        [Test]
        public void AnyShouldWorkProperlyWithCount()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("s1", 50));
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void AnyShouldThrowsAnExceptionWhenPhoneAlreadyExist()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("s1", 50));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("s1", 60)));
        }
        [Test]
        public void AnyShouldThrowsAnExceptionWhenShopIsFull()
        {
            Shop shop = new Shop(1);
            shop.Add(new Smartphone("s1", 50));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("s2", 60)));
        }
        [Test]
        public void RemoveShouldWorkProperly()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("s1", 50));
            shop.Remove("s1");
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void RemoveShouldThrowsAnExceptionWhenPhoneDoesntExist()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("s1", 50));
            Assert.Throws<InvalidOperationException>(() => shop.Remove("s2"));
        }
        [Test]
        public void TestPhoneShouldWorkProperly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("s1", 50);
            shop.Add(phone);
            shop.TestPhone("s1", 10);
            Assert.AreEqual(40, phone.CurrentBateryCharge);
        }
        [Test]
        public void TestPhoneShouldThrowsAnExceptionWhenPhoneIsNull()
        {
            Shop shop = new Shop(5);    
            shop.Add(new Smartphone("s1", 50));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("s2", 50));
        }
        [Test]
        public void TestPhoneShouldThrowsAnExceptionWhenCurrentBatteryChargeIsLessThanNatteryUsage()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("s1", 50));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("s1", 51));
        }
        [Test]
        public void ChargePhoneShouldWorkProperly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("s1", 50);
            shop.Add(phone);
            shop.TestPhone("s1", 41);
            shop.ChargePhone("s1");
            Assert.AreEqual(50, phone.CurrentBateryCharge);
        }
        [Test]
        public void ChargePhoneShouldThrowsAnExceptionWhenPhoneDoesntExist()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("s1", 50);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("s2"));
        }
    }
}