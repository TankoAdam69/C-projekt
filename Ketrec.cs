using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Ketrec
    {
        public string Név { get; set; }
        public List<Állat> Állat { get; set; }

        public Ketrec(string név, List<Állat> állat)
        {
            Név = név;
            this.Állat = állat;
        }

        public string Nyitás()
        {
            return $"{Név} ketrec nyitva.";
        }

        public string Zárás()
        {
            return $"{Név} ketrec zárva.";
        }

    }
}
