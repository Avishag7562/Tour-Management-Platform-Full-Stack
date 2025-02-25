using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int CodeUser { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? EntryPassword { get; set; }

    public bool? FirstAid { get; set; }

    public virtual ICollection<OrederPlace> OrederPlaces { get; set; } = new List<OrederPlace>();
}
