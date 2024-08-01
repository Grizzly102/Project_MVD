using System;
using System.Collections.Generic;

namespace kartoteka.Model;

public partial class Title
{
    public int TitleId { get; set; }

    public string? TitleName { get; set; }

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
