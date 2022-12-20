using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void ConstrutorShouldWorkProperly()
            {
                Garage cars = new Garage("g1", 3);
                Assert.AreEqual(3, cars.MechanicsAvailable);
                Assert.AreEqual("g1", cars.Name);
            }
            [Test]
            public void NamePropertyShouldThrowsAnExceptionWhenNameIsNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage("", 3));
            }
            [Test]
            public void MechanicsAvailableShouldThrowsAnExceptionWhenLessThanOne()
            {
                Assert.Throws<ArgumentException>(() => new Garage("g1", 0));
            }
            [Test]
            public void AddCarShouldWorkProperly()
            {
                Garage cars = new Garage("g1", 3);
                cars.AddCar(new Car("c1", 2));
                Assert.AreEqual(1, cars.CarsInGarage);
            }
            [Test]
            public void AddCarShouldThrowsAnExceptionWhenCarIsNull()
            {
                Garage cars = new Garage("g1", 1);
                cars.AddCar(null);
                Assert.Throws<InvalidOperationException>(() => cars.AddCar(null));
            }
            [Test]
            public void FixCarShouldWorkProperly()
            {
                Garage cars = new Garage("g1", 3);
                Car car = new Car("c1", 2);
                cars.AddCar(car);
                cars.FixCar("c1");
                Assert.AreEqual(0, car.NumberOfIssues);
            }
            [Test]
            public void FixCarShouldThrowsAnExceptionWhenCarIsNotFound()
            {
                Garage cars = new Garage("g1", 1);
                cars.AddCar(new Car("c1", 2));
                Assert.Throws<InvalidOperationException>(() => cars.FixCar("c2"));
            }
            [Test]
            public void RemoveCarShouldWorkProperly()
            {
                Garage cars = new Garage("g1", 1);
                cars.AddCar(new Car("c1", 2));              
                cars.FixCar("c1");
                cars.RemoveFixedCar();
                Assert.AreEqual(0, cars.CarsInGarage);
            }
            [Test]
            public void RemoveCarShouldThrowsAnExceptionWhenCarCountIsZero()
            {
                Garage cars = new Garage("g1", 1);
                cars.AddCar(new Car("c1", 2));
                Assert.Throws<InvalidOperationException>(() => cars.RemoveFixedCar());
            }
            [Test]
            public void ReportShouldReturnCorrectMessage()
            {
                Garage cars = new Garage("g1", 3);
                cars.AddCar(new Car("c1", 2));
                cars.AddCar(new Car("c2", 2));
                cars.AddCar(new Car("c3", 2));
                cars.FixCar("c1");
                string expected = $"There are 2 which are not fixed: c2, c3.";
                Assert.AreEqual(expected, cars.Report());
            }
        }
    }
}