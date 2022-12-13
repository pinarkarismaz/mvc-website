using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace astro1.Models
{
    public class Burc
    {
        public int Id { get; set; }
        public string burc_adi { get; set; }
        public string burc_tarihi { get; set; }
        public string burc_resim { get; set; }
        public int grup_Id { get; set; }
        public Grup burc_grup { get; set; }
    }
}
