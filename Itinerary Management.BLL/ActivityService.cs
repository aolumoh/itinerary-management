using AutoMapper;
using Itinerary_Management.DAL;
using Itinerary_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.BLL {
    public class ActivityService {
        private readonly ActivityDAL _activityDAL;
        private readonly ItineraryDAL _itineraryDAL;
        private readonly IMapper _mapper;

        public ActivityService(ActivityDAL activityDAL, ItineraryDAL itineraryDAL, IMapper mapper) {
            _activityDAL = activityDAL;
            _itineraryDAL = itineraryDAL;
            _mapper = mapper;
        }

        public async Task<List<ActivityDTO>> GetAllActivitiesAsync() {
            var activities = await _activityDAL.GetAllActivitiesAsync();
            return _mapper.Map<List<ActivityDTO>>(activities);
        }

        public async Task<ActivityDTO> GetActivityByIdAsync(int id) {
            var activity = await _activityDAL.GetActivityByIdAsync(id);
            return _mapper.Map<ActivityDTO>(activity);
        }

        public async Task AddActivityAsync(ActivityDTO activityDTO) {
            // Find the first itinerary matching the name provided
            var itinerary = await _itineraryDAL.GetItineraryByNameAsync(activityDTO.ItineraryName);

            if (itinerary == null) {
                throw new Exception($"Itinerary with the name '{activityDTO.ItineraryName}' not found.");
            }

            // Map the DTO to the entity and set the ItineraryId
            var activity = _mapper.Map<Activity>(activityDTO);
            activity.ItineraryId = itinerary.ItineraryId;
            activity.Itinerary = itinerary;

            await _activityDAL.AddActivityAsync(activity);
        }

        public async Task UpdateActivityAsync(ActivityDTO activityDTO) {
            var activity = _mapper.Map<Activity>(activityDTO);
            await _activityDAL.UpdateActivityAsync(activity);
        }

        public async Task DeleteActivityAsync(int id) {
            await _activityDAL.DeleteActivityAsync(id);
        }
    }
}
