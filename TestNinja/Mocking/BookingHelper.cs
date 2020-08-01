using System;
using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class BookingHelper
    {
        private readonly UnitOfWork _unitOfWork;

        public BookingHelper(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public string OverlappingBookingsExist(Booking booking)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var otherNotCancelledBookings = _unitOfWork
                .Query<Booking>()
                .Where(b => b.Id != booking.Id && b.Status != "Cancelled");

            var overlappingBooking = otherNotCancelledBookings
                .FirstOrDefault(b => IsBookingsOverlapped(booking, b));

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }

        private bool IsBookingsOverlapped(Booking b1, Booking b2)
        {
            return b1.ArrivalDate >= b2.ArrivalDate && b1.ArrivalDate < b2.DepartureDate
                || b2.ArrivalDate < b1.DepartureDate && b2.DepartureDate >= b1.DepartureDate;
        }
    }

    public class UnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}