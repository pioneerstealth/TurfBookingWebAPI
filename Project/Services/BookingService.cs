using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TurfBooking.Models;


namespace TurfBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly TurfBookingContext _context;

        public BookingService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingDTO> GetBookings()
        {
            return _context.Bookings.Select(MapToDTO).ToList();
        }

        public BookingDTO GetBooking(int id)
        {
            var Booking = _context.Bookings.Find(id);
            return Booking != null ? MapToDTO(Booking) : null;

        }

        public BookingDTO AddBooking(NewBookingDTO newBookingDTO)
        {
            var newBooking = new Booking
            {
                BookingDate = newBookingDTO.BookingDate,
                Duration = newBookingDTO.Duration,
                TurfId = newBookingDTO.TurfId,
                UserId = newBookingDTO.UserId
            };

            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            // Map the newly created Booking entity to a BookingDTO
            var bookingDTO = MapToDTO(newBooking);

            return bookingDTO;
        }

        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
        private BookingDTO MapToDTO(Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                Duration = booking.Duration,
                UserId = booking.UserId,
                UserName = booking.User?.Name ?? "Unknown" , // Assuming User navigation property exists
                TurfId = booking.TurfId,
                TurfName = booking.Turf?.Name ?? "Unknown" // Assuming Turf navigation property exists
            };
        }



    }
}
