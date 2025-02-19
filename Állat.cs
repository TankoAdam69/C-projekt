using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Állat
    {
        public string Név { get; set; }
        public string Fajta { get; set; }

        public Állat(string név, string fajta)
        {
            Név = név;
            Fajta = fajta;
        }

        public string Eszik()
        {
            return $"{Név}, a {Fajta}, eszik.";
        }

        public string Mozog()
        {
            return $"{Név}, a {Fajta}, mozog.";
        }
    }



}
