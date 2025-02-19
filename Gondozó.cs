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

        public string Tisztít(Ketrec ketrec)
        {
            return $"{Név} tisztítja a(z) {ketrec.Név}."; 
        }

        public string Etet(Ketrec ketrec)
        {
            string temp = "";
            foreach (var item in ketrec.Állat)
                temp += $"{Név} eteti {item.Név}-t, a(z) {item.Fajta}-t";
            return temp;
        }
    }


}
