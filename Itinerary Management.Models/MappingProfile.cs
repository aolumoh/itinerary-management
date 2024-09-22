using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinerary_Management.Models {
    public class MappingProfile : Profile{
        public MappingProfile() {
            CreateMap<Itinerary, ItineraryDTO>().ReverseMap();
            CreateMap<Flight, FlightDTO>().ReverseMap(); ;
            CreateMap<Stay, StayDTO>().ReverseMap();
            CreateMap<Activity, ActivityDTO>().ReverseMap();
        }
    }
}
