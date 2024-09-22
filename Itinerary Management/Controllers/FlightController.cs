using Itinerary_Management.BLL;
using Itinerary_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary_Management.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase {
        private readonly FlightService _flightService;

        public FlightController(FlightService flightService) {
            _flightService = flightService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateFlight(FlightDTO flightDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _flightService.AddFlightAsync(flightDTO);
            return CreatedAtAction(nameof(GetFlight), new { id = flightDTO.FlightId }, flightDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDTO>>> GetAllFlights() {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDTO>> GetFlight(int id) {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, FlightDTO flightDTO) {
            if (id != flightDTO.FlightId) {
                return BadRequest();
            }

            await _flightService.UpdateFlightAsync(flightDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id) {
            await _flightService.DeleteFlightAsync(id);
            return NoContent();
        }
    }
}
