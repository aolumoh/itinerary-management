using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class Activity {
        public int ActivityId { get; set; }
        public int ItineraryId { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
