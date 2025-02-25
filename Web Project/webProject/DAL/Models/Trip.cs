using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
{
    public int CodeTrip { get; set; }

    public string? Destination { get; set; }

    public int? CodeType { get; set; }

    public DateTime? DateTrip { get; set; }

    public TimeSpan? LeavingTime { get; set; }

    public int? TripHours { get; set; }

    public int? AvailablePlaces { get; set; }

    public decimal? Price { get; set; }

    public string? Img { get; set; }

    public virtual TravelType? CodeTypeNavigation { get; set; }

    public virtual ICollection<OrederPlace> OrederPlaces { get; set; } = new List<OrederPlace>();
}
