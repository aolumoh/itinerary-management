using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class ItineraryDTO {
        public int ItineraryId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<FlightDTO> Flights { get; set; } = new List<FlightDTO>();
        public List<StayDTO> Stays { get; set; } = new List<StayDTO>();
        public List<ActivityDTO> Activities { get; set; } = new List<ActivityDTO>();
    }
}
