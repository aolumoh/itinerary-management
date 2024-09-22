using AutoMapper;
using Itinerary_Management.DAL;
using Itinerary_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.BLL {
    public class FlightService {
        private readonly FlightDAL _flightDAL;
        private readonly ItineraryDAL _itineraryDAL;
        private readonly IMapper _mapper;

        public FlightService(FlightDAL flightDAL, ItineraryDAL itineraryDAL, IMapper mapper) {
            _flightDAL = flightDAL;
            _itineraryDAL = itineraryDAL;
            _mapper = mapper;
        }

        public async Task<List<FlightDTO>> GetAllFlightsAsync() {
            var flights = await _flightDAL.GetAllFlightsAsync();
            return _mapper.Map<List<FlightDTO>>(flights);
        }

        public async Task<FlightDTO> GetFlightByIdAsync(int id) {
            var flight = await _flightDAL.GetFlightByIdAsync(id);
            return _mapper.Map<FlightDTO>(flight);
        }

        public async Task AddFlightAsync(FlightDTO flightDTO) {
            var itinerary = await _itineraryDAL.GetItineraryByNameAsync(flightDTO.ItineraryName);

            if (itinerary == null) {
                throw new Exception($"Itinerary with the name '{flightDTO.ItineraryName}' not found.");
            }

            var flight = _mapper.Map<Flight>(flightDTO);
            flight.ItineraryId = itinerary.ItineraryId;
            flight.Itinerary = itinerary;

            await _flightDAL.AddFlightAsync(flight);
        }

        public async Task UpdateFlightAsync(FlightDTO flightDTO) {
            var flight = _mapper.Map<Flight>(flightDTO);
            await _flightDAL.UpdateFlightAsync(flight);
        }

        public async Task DeleteFlightAsync(int id) {
            await _flightDAL.DeleteFlightAsync(id);
        }
    }
}
