using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class Stay {
        public int StayId { get; set; }
        public int ItineraryId { get; set; }
        public string AccommodationName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Itinerary Itinerary { get; set; }
    }
}
