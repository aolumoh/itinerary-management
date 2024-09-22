using Itinerary_Management.BLL;
using Itinerary_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary_Management.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase {
        private readonly ItineraryService _itineraryService;

        public ItineraryController(ItineraryService itineraryService) {
            _itineraryService = itineraryService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateItinerary(ItineraryDTO itineraryDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _itineraryService.AddItineraryAsync(itineraryDTO);
            return CreatedAtAction(nameof(GetItinerary), new { id = itineraryDTO.ItineraryId }, itineraryDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItineraryDTO>>> GetAllItineraries() {
            var itineraries = await _itineraryService.GetAllItinerariesAsync();
            return Ok(itineraries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItineraryDTO>> GetItinerary(int id) {
            var itinerary = await _itineraryService.GetItineraryByIdAsync(id);
            if (itinerary == null) {
                return NotFound();
            }
            return Ok(itinerary);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItinerary(int id, ItineraryDTO itineraryDTO) {
            if (id != itineraryDTO.ItineraryId || !ModelState.IsValid) {
                return BadRequest();
            }

            await _itineraryService.UpdateItineraryAsync(itineraryDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerary(int id) {
            await _itineraryService.DeleteItineraryAsync(id);
            return NoContent();
        }
    }
}
