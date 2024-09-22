using AutoMapper;
using Itinerary_Management.DAL;
using Itinerary_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.BLL {
    public class StayService {
        private readonly StayDAL _stayDAL;
        private readonly ItineraryDAL _itineraryDAL;
        private readonly IMapper _mapper;

        public StayService(StayDAL stayDAL, ItineraryDAL itineraryDAL, IMapper mapper) {
            _stayDAL = stayDAL;
            _itineraryDAL = itineraryDAL;
            _mapper = mapper;
        }

        public async Task<List<StayDTO>> GetAllStaysAsync() {
            var stays = await _stayDAL.GetAllStaysAsync();
            return _mapper.Map<List<StayDTO>>(stays);
        }

        public async Task<StayDTO> GetStayByIdAsync(int id) {
            var stay = await _stayDAL.GetStayByIdAsync(id);
            return _mapper.Map<StayDTO>(stay);
        }

        public async Task AddStayAsync(StayDTO stayDTO) {
            var itinerary = await _itineraryDAL.GetItineraryByNameAsync(stayDTO.ItineraryName);

            if (itinerary == null) {
                throw new Exception($"Itinerary with the name '{stayDTO.ItineraryName}' not found.");
            }

            var stay = _mapper.Map<Stay>(stayDTO);
            stay.ItineraryId = itinerary.ItineraryId;
            stay.Itinerary = itinerary;

            await _stayDAL.AddStayAsync(stay);
        }

        public async Task UpdateStayAsync(StayDTO stayDTO) {
            var stay = _mapper.Map<Stay>(stayDTO);
            await _stayDAL.UpdateStayAsync(stay);
        }

        public async Task DeleteStayAsync(int id) {
            await _stayDAL.DeleteStayAsync(id);
        }
    }
}
