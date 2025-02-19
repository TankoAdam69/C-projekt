using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Látogató
    {
        public string Név { get; set; }
        public bool Diák { get; set; }

        public Látogató(string név, bool diák)
        {
            Név = név;
            Diák = diák;
        }

        public string Nézelődik()
        {
            return $"{Név} nézelődik az állatkertben.";
        }

        public double Belépő()
        {
            double belépő = Diák ? 500 : 1000; // Diákoknak kedvezmény, 500 Ft
            if (Diák) {
                Console.WriteLine($"{Név} diák belépővel látogatja az állatkertet: + {belépő} Ft");
            }
            else
            {
                Console.WriteLine($"{Név} felnőtt belépővel látogatja az állatkertet: + {belépő} Ft");
            }

            return belépő;
        }
    }
}
