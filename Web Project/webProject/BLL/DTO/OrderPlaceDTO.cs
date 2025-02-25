using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderPlaceDTO
    {
        public int CodeOrder { get; set; }

        public int? CodeUser { get; set; }

        public DateTime? DateOrder { get; set; }

        public TimeSpan? OrderHour { get; set; }

        public int CodeTrip { get; set; }

        public int? NumPlaces { get; set; }

        public string? fullName { get; set; }

        public string? destination { get; set; }

        public DateTime? Date { get; set; }
    }
}
