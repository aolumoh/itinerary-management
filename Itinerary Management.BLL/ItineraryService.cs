using AutoMapper;
using Itinerary_Management.DAL;
using Itinerary_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.BLL {
    public class ItineraryService {
        private readonly ItineraryDAL _itineraryDAL;
        private readonly IMapper _mapper;

        public ItineraryService(ItineraryDAL itineraryDAL, IMapper mapper) {
            _itineraryDAL = itineraryDAL;
            _mapper = mapper;
        }

        public async Task<List<ItineraryDTO>> GetAllItinerariesAsync() {
            var itineraries = await _itineraryDAL.GetAllItinerariesAsync();
            return _mapper.Map<List<ItineraryDTO>>(itineraries);
        }

        public async Task<ItineraryDTO> GetItineraryByIdAsync(int id) {
            var itinerary = await _itineraryDAL.GetItineraryByIdAsync(id);
            return _mapper.Map<ItineraryDTO>(itinerary);
        }

        public async Task AddItineraryAsync(ItineraryDTO itineraryDTO) {
            // Check if an itinerary with the same name already exists
            var existingItinerary = await _itineraryDAL.GetItineraryByNameAsync(itineraryDTO.Name);

            if (existingItinerary != null) {
                throw new Exception($"An itinerary with the name '{itineraryDTO.Name}' already exists.");
            }

            var itinerary = _mapper.Map<Itinerary>(itineraryDTO);
            await _itineraryDAL.AddItineraryAsync(itinerary);
        }

        public async Task UpdateItineraryAsync(ItineraryDTO itineraryDTO) {
            var itinerary = _mapper.Map<Itinerary>(itineraryDTO);
            await _itineraryDAL.UpdateItineraryAsync(itinerary);
        }

        public async Task DeleteItineraryAsync(int id) {
            await _itineraryDAL.DeleteItineraryAsync(id);
        }
    }
}
