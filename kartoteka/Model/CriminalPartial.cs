using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartoteka.Model
{
    public partial class Criminal
    {
        public string Image { get { return Photo != null ? $"/Resources/{Photo}" : null; } }
    }
}
