using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> books;
        public BookingRepository()
        {
            books = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            books.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return books.AsReadOnly();
        }

        public IBooking Select(string criteria)
        {
            return books.Find(x => x.GetType().Name == criteria);
        }
    }
}
