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
            return $"{Név} tisztítja a {ketrec.Név}."; 
        }

        public string Etet(Ketrec ketrec)
        {
            string temp = "";
            foreach (var item in ketrec.Állat)
                temp += $"{Név} eteti {item.Név}-t, a {item.Fajta}-t";
            return temp;
        }
    }


}
