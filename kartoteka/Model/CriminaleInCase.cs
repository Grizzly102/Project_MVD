using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class CriminaleInCase
{
    public int? CaseId { get; set; }

    public long? PassportNuberSerias { get; set; }

    public string? CaseStatus { get; set; }

    public int CiCNumber { get; set; }

    public virtual Case? Case { get; set; }

    public virtual Criminal? PassportNuberSeriasNavigation { get; set; }
}
