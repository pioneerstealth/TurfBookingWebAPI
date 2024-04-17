using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services;
using TurfBooking.DTO;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurfController : ControllerBase
    {
        private readonly ITurfService _turfService;

        public TurfController(ITurfService turfService)
        {
            _turfService = turfService;
        }

        // GET: api/Turf
        [HttpGet]
        public ActionResult<IEnumerable<TurfDTO>> GetTurfs()
        {
            var turfs = _turfService.GetTurfs();
            if (turfs == null)
            {
                return NotFound(); // Return a NotFoundResult if no users are found
            }
            return Ok(turfs);
        }

        // GET: api/Turf/5
        [HttpGet("{id}")]
        public ActionResult<TurfDTO> GetTurf(int id)
        {
            var turf = _turfService.GetTurf(id);

            if (turf == null)
            {
                return NotFound();
            }

            return turf;
        }

        // POST: api/Turf
        [HttpPost]
        public ActionResult<TurfDTO> PostTurf(NewTurfDTO turf)
        {
            var createdTurf = _turfService.AddTurf(turf);
            // Assuming AddTurf method now returns the created TurfDTO with an Id
            return CreatedAtAction(nameof(GetTurf), new { id = createdTurf.Id }, createdTurf);
        }


        // PUT: api/Turf/5
        [HttpPut("{id}")]
        public IActionResult PutTurf(int id, UpdateAvailabilityDTO turf)
        {
            

            _turfService.UpdateTurf(id,turf);

            return NoContent();
        }

        // DELETE: api/Turf/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTurf(int id)
        {
            _turfService.DeleteTurf(id);
            return NoContent();
        }
    }
}

