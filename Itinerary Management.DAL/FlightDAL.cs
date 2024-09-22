using Itinerary_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.DAL {
    public class FlightDAL {
        private readonly ItineraryDbContext _context;

        public FlightDAL(ItineraryDbContext context) {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlightsAsync() {
            return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> GetFlightByIdAsync(int id) {
            return await _context.Flights.FindAsync(id);
        }

        public async Task AddFlightAsync(Flight flight) {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlightAsync(Flight flight) {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id) {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null) {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }
    }
}
