using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
