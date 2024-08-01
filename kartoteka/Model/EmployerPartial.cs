using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartoteka.Model
{
    public partial class Employer
    {
        public string ImagePolice { get { return PolicePhoto != null ? $"/Resources/{PolicePhoto}" : null; } }
    }
}
