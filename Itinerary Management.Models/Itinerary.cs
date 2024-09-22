using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class Itinerary {
        public int ItineraryId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Flight> Flights { get; set; }
        public ICollection<Stay> Stays { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
