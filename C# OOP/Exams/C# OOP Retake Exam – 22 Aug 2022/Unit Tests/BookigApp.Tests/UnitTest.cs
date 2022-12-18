using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        Room room;
        Hotel hotel;
        Booking book;

        [SetUp]
        public void Setup()
        {
            room = new Room(3, 20);
            hotel = new Hotel("h1", 2);
            book = new Booking(12, room, 10);
        }

        [Test]
        public void BookingConstructorShouldWorkCorrectlyWithProperties()
        {
            Assert.AreEqual(12, book.BookingNumber);
            Assert.AreEqual(room, book.Room);
            Assert.AreEqual(10, book.ResidenceDuration);
        }
        [Test]
        public void RoomConstructorShouldWorkCorrectlyWithProperties()
        {
            Assert.AreEqual(3, room.BedCapacity);
            Assert.AreEqual(20, room.PricePerNight);
        }
        [Test]
        public void RoomBedCapacityShouldThrowsAnExceptionWhenIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Room(-3, 20));
        }
        [Test]
        public void RoomPriceShouldThrowsAnExceptionWhenIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Room(3, -20));
        }
        [Test]
        public void HotelConstructorShouldWorkCorrectlyWithProperties()
        {
            Assert.AreEqual("h1", hotel.FullName);
            Assert.AreEqual(2, hotel.Category);
        }
        [Test]
        public void HotelRoomShouldThrowsAnExceptionWhenRoomIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 2));
        }
        [Test]
        public void HotelRoomShouldThrowsAnExceptionWhenCategoryIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Hotel("h1", 10));
        }
        [Test]
        public void AddRoomShouldWorkProperly()
        {
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
        }
        [Test]
        public void BookRoomShouldWorkProperly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 2, 2, 50);
            Assert.AreEqual(40, hotel.Turnover);
        }
        [Test]
        public void BookRoomShouldThrowsAnExceptions()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 2, 50));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -2, 2, 50));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, -2, 50));
        }
        [Test]
        public void BookingShouldWorkProperly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 2, 2, 50);
            Assert.AreEqual(1, hotel.Bookings.Count);
        }
    }
}