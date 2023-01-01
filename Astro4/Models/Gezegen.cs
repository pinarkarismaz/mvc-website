using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Astro4.Models
{
    public class Gezegen
    {
        public int ID { get; set; }
        public string tarih_ad { get; set; }
        public int gun_burc { get; set; }
    }
}
