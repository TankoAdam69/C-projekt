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
        public Állat Állat { get; set; }

        public Ketrec(string név, Állat állat)
        {
            Név = név;
            Állat = állat;
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
