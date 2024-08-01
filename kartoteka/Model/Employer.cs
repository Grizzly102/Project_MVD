using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class Employer
{
    public int TokenNumber { get; set; }

    public string? EmployeeName { get; set; }

    public int? DepartmentNumber { get; set; }

    public int? TitleNumber { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? PolicePhoto { get; set; }

    public virtual ICollection<Case> Cases { get; set; } = new List<Case>();

    public virtual Department? DepartmentNumberNavigation { get; set; }

    public virtual Title? TitleNumberNavigation { get; set; }
}
