using Itinerary_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.DAL {
    public class StayDAL {
        private readonly ItineraryDbContext _context;

        public StayDAL(ItineraryDbContext context) {
            _context = context;
        }

        public async Task<List<Stay>> GetAllStaysAsync() {
            return await _context.Stays.ToListAsync();
        }

        public async Task<Stay> GetStayByIdAsync(int id) {
            return await _context.Stays.FindAsync(id);
        }

        public async Task AddStayAsync(Stay stay) {
            await _context.Stays.AddAsync(stay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStayAsync(Stay stay) {
            _context.Stays.Update(stay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStayAsync(int id) {
            var stay = await _context.Stays.FindAsync(id);
            if (stay != null) {
                _context.Stays.Remove(stay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
