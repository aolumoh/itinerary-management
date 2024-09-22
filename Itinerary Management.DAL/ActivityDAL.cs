using Itinerary_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.DAL {
    public class ActivityDAL {
        private readonly ItineraryDbContext _context;

        public ActivityDAL(ItineraryDbContext context) {
            _context = context;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync() {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id) {
            return await _context.Activities.FindAsync(id);
        }

        public async Task AddActivityAsync(Activity activity) {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity) {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(int id) {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null) {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
