using System;
using System.Collections.Generic;

namespace ThreeLayerArchitecture.ASP.Net.DAL;

public partial class Gender
{

    public int Id { get; set; }

    public string? TExt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
