﻿using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotel;
        public HotelRepository()
        {
            hotel = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            hotel.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return hotel.AsReadOnly();
        }

        public IHotel Select(string criteria)
        {
            return hotel.Find(x => x.FullName == criteria);
        }
    }
}
