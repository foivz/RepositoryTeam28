using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booker.Model
{
    class DgdPosudba
    {
    
        public string Administrator { get; set; }
        public string Korisnik { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }
        public string Knjiga { get; set; }
    }
}
