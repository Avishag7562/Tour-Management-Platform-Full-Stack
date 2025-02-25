using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TripDTO
    {
        public int CodeTrip { get; set; }

        public string? Destination { get; set; }

        public int? CodeType { get; set; }

        public DateTime? DateTrip { get; set; }

        public TimeSpan? LeavingTime { get; set; }

        public int? TripHours { get; set; }

        public int AvailablePlaces { get; set; }

        public decimal? Price { get; set; }

        public string? Img { get; set; }

        public TravelTypeDTO? typeTrip { get; set; }

        public bool? isMedic{ get; set ; }
    }
}
