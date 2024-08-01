using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartoteka.Model
{
    public partial class Case
    {
        public string NameP { get { return CaseConductNavigation.EmployeeName; } }

    }
}
