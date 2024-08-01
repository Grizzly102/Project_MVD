using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartoteka.Model
{
    public partial class CriminaleInCase
    {
        public string ImageP { get { return PassportNuberSeriasNavigation.Photo != null ? $"/Resources/{PassportNuberSeriasNavigation.Photo}" : null; } }

    }
}
