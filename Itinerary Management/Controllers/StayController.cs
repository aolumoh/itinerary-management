using Itinerary_Management.BLL;
using Itinerary_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary_Management.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StayController : ControllerBase {
        private readonly StayService _stayService;

        public StayController(StayService stayService) {
            _stayService = stayService;
        }


        [HttpPost]
        public async Task<ActionResult> CreateStay(StayDTO stayDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await _stayService.AddStayAsync(stayDTO);
            return CreatedAtAction(nameof(GetStay), new { id = stayDTO.StayId }, stayDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StayDTO>>> GetAllStays() {
            var stays = await _stayService.GetAllStaysAsync();
            return Ok(stays);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StayDTO>> GetStay(int id) {
            var stay = await _stayService.GetStayByIdAsync(id);
            if (stay == null) {
                return NotFound();
            }
            return Ok(stay);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateStay(int id, StayDTO stayDTO) {
            if (id != stayDTO.StayId) {
                return BadRequest();
            }

            await _stayService.UpdateStayAsync(stayDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStay(int id) {
            await _stayService.DeleteStayAsync(id);
            return NoContent();
        }
    }
}
