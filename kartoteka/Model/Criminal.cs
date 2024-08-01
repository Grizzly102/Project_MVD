using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class Criminal
{
    public long PassportNuberSerias { get; set; }

    public string? CriminalName { get; set; }

    public int? Height { get; set; }

    public string? EyeColor { get; set; }

    public string? HairColor { get; set; }

    public string? SpecialSigns { get; set; }

    public string? BirthPlace { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? LastResidencePlace { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<CriminaleInCase> CriminaleInCases { get; set; } = new List<CriminaleInCase>();
}
