using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services; 

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Booking
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            var bookings= _bookingService.GetBookings();
            if (bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public ActionResult<BookingDTO> GetBooking(int id)
        {
            var booking = _bookingService.GetBooking(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // POST: api/Booking
        [HttpPost]
        public ActionResult<BookingDTO> PostBooking(NewBookingDTO booking)
        {
            var createdbooking = _bookingService.AddBooking(booking);
            return CreatedAtAction("GetBooking", new { id = createdbooking.Id }, createdbooking);
        }

        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public IActionResult PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _bookingService.UpdateBooking(booking);

            return NoContent();
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
