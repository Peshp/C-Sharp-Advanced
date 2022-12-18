﻿using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IBooking> bookings;
        private IRepository<IRoom> rooms;
        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value <= 1 || value > 6)
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double turnover = 0;
                foreach (var i in bookings.All())
                    turnover += i.ResidenceDuration * i.Room.PricePerNight;
                return turnover;
            }
        }

        public IRepository<IRoom> Rooms => rooms;

        public IRepository<IBooking> Bookings => bookings;
    }
}
