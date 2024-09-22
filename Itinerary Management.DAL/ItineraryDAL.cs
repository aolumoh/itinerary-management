using Itinerary_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.DAL {
    public class ItineraryDAL {
        private readonly ItineraryDbContext _context;

        public ItineraryDAL(ItineraryDbContext context) {
            _context = context;
        }

        public async Task<List<Itinerary>> GetAllItinerariesAsync() {
            return await _context.Itineraries.Include(i => i.Flights).Include(i => i.Stays).Include(i => i.Activities).ToListAsync();
        }

        public async Task<Itinerary> GetItineraryByIdAsync(int id) {
            return await _context.Itineraries.Include(i => i.Flights).Include(i => i.Stays).Include(i => i.Activities).FirstOrDefaultAsync(i => i.ItineraryId == id);
        }

        public async Task<Itinerary> GetItineraryByNameAsync(string itineraryName) {
            // Search for the first itinerary that matches the given name
            return await _context.Itineraries.FirstOrDefaultAsync(i => i.Name == itineraryName);
        }

        public async Task AddItineraryAsync(Itinerary itinerary) {
            await _context.Itineraries.AddAsync(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItineraryAsync(Itinerary itinerary) {
            _context.Itineraries.Update(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItineraryAsync(int id) {
            var itinerary = await _context.Itineraries.FindAsync(id);
            if (itinerary != null) {
                _context.Itineraries.Remove(itinerary);
                await _context.SaveChangesAsync();
            }
        }
    }
}
