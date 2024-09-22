using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class StayDTO {
        public int StayId { get; set; }
        public string AccommodationName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string City { get; set; }
        public string ItineraryName { get; set; }
    }
}
