using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = new Hotel(hotelName, category);
            if (hotels.Select(hotelName) != null)
                return $"Hotel {hotelName} is already registered in our platform.";
            hotels.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (!hotels.All().Any(x => x.Category == category))
                return String.Format(OutputMessages.CategoryInvalid, category);

            var availableRooms = new Dictionary<IRoom, string>();

            foreach (var hotel in hotels.All().Where(x => x.Category == category).OrderBy(x => x.FullName))
                foreach (var room in hotel.Rooms.All())
                    if (room.PricePerNight > 0)
                        availableRooms.Add(room, hotel.FullName);

            IRoom roomToBook = null;
            string hotelNameToBook = string.Empty;
            int people = adults + children;

            foreach (var room in availableRooms.OrderBy(x => x.Key.BedCapacity))
            {
                if (room.Key.BedCapacity >= people)
                {
                    roomToBook = room.Key;
                    hotelNameToBook = room.Value;
                    break;
                }
            }

            if (roomToBook == null)
                return String.Format(OutputMessages.RoomNotAppropriate);

            IHotel hotelToBook = hotels.Select(hotelNameToBook);
            int newBookingNumber = hotelToBook.Bookings.All().Count + 1;

            Booking newBooking = new Booking(roomToBook, duration, adults, children, newBookingNumber);
            hotelToBook.Bookings.AddNew(newBooking);

            return String.Format(OutputMessages.BookingSuccessful, newBookingNumber, hotelNameToBook);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.Append("none");
                return sb.ToString();
            }
            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
            }
            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (hotels.Select(hotelName) == null)
                return $"Profile {hotelName} doesn’t exist!";
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
                throw new ArgumentException("Incorrect room type!");
            if (room == null)
                return "Room type is not created yet!";
            if (room.PricePerNight != 0)
                return "Price is already set!";

            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            IRoom room;
            if (hotel == null)
                return $"Profile {hotelName} doesn’t exist!";
            if (hotel.Rooms.Select(roomTypeName) != null)
                return "Room type is already created!";

            switch (roomTypeName)
            {
                case "Apartment": room = new Apartment(); break;
                case "DoubleBed": room = new DoubleBed(); break;
                case "Studio": room = new Studio(); break;
                default: return "Incorrect room type!";
            }
            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
