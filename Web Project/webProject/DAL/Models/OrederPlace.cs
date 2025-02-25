using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrederPlace
{
    public int CodeOrder { get; set; }

    public int? CodeUser { get; set; }

    public DateTime? DateOrder { get; set; }

    public TimeSpan? OrderHour { get; set; }

    public int? CodeTrip { get; set; }

    public int? NumPlaces { get; set; }

    public virtual Trip? CodeTripNavigation { get; set; }

    public virtual User? CodeUserNavigation { get; set; }
}
