using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class Case
{
    public int CaseId { get; set; }

    public DateOnly? CaseOpeningDate { get; set; }

    public DateOnly? CrimeDate { get; set; }

    public string? CrimeScence { get; set; }

    public int? CrimeArticle { get; set; }

    public string? CrimeWeight { get; set; }

    public int? CaseConduct { get; set; }

    public string? Discription { get; set; }

    public virtual Employer? CaseConductNavigation { get; set; }

    public virtual ICollection<CriminaleInCase> CriminaleInCases { get; set; } = new List<CriminaleInCase>();
}
