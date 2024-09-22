using Itinerary_Management.BLL;
using Itinerary_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary_Management.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase {
        private readonly ActivityService _activityService;

        public ActivityController(ActivityService activityService) {
            _activityService = activityService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(ActivityDTO activityDTO) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _activityService.AddActivityAsync(activityDTO);
            return CreatedAtAction(nameof(GetActivity), new { id = activityDTO.ActivityId }, activityDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDTO>>> GetAllActivities() {
            var activities = await _activityService.GetAllActivitiesAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDTO>> GetActivity(int id) {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null) {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, ActivityDTO activityDTO) {
            if (id != activityDTO.ActivityId) {
                return BadRequest();
            }

            await _activityService.UpdateActivityAsync(activityDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id) {
            await _activityService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
