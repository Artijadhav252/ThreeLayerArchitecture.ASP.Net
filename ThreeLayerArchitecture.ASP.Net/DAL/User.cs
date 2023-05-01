using System;
using System.Collections.Generic;
using ThreeLayerArchitecture.ASP.Net.Models;

namespace ThreeLayerArchitecture.ASP.Net.DAL;

public partial class User
{

    

   
    internal int id;

    public int Id { get; set; }

    public string? EmailId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? GenderId { get; set; }

    public string? MobileNumber { get; set; }

    public string? Password { get; set; }

    public string? AdharNumber { get; set; }

    public string? Category { get; set; }

    public bool? TermsConditions { get; set; }

    public virtual Gender? Gender { get; set; }

    internal void ConvertUserVMToUserDTO()
    {
        throw new NotImplementedException();
    }
}
