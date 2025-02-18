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

        public Látogató(string név)
        {
            Név = név;
        }

        public string Nézelődik()
        {
            return $"{Név} nézelődik az állatkertben.";
        }
    }


}
