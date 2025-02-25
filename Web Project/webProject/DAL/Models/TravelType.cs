using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TravelType
{
    public int CodeType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
