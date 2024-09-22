using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class ActivityDTO {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        [Required]
        public string ItineraryName { get; set; }

    }
}
