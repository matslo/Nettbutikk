using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nettbutikken.Model
{
   public class Kvitto
    {
        public int OrdreId { get; set; }
        public System.DateTime OrdreDato { get; set; }
        public string Brukernavn { get; set; }
        public string Varenavn { get; set; }
        public decimal Total { get; set; }
        public int Antall { get; set; }
    }
}
