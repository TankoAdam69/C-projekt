using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Gondozó
    {
        public string Név { get; set; }

        public Gondozó(string név)
        {
            Név = név;
        }

        public string Gondozza(Állat állat)
        {
            return $"{Név} gondozza {állat.Név}-t.";
        }

        public string Tisztít(Ketrec ketrec)
        {
            return $"{Név} tisztítja a {ketrec.Név} ketrecet."; // Fixed the wording here
        }

        public string Etet(Ketrec ketrec)
        {
            return $"{Név} eteti {ketrec.Állat.Név}-t, a {ketrec.Állat.Fajta}-t."; // Add feeding functionality
        }
    }


}
