using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_DopravniProstredek
{
    internal class Kocarek : IPojizdny
    {
        public int PocetKol { get; private set; }

        public Kocarek(int pocetKol)
        {
            PocetKol = pocetKol;
        }
    }
}
