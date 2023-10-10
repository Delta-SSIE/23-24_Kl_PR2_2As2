using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_051_Lanovka_ukazatele
{
    internal class Clovek
    {
        public int Hmotnost { get; set; }
        public string Jmeno { get; set; }

        public Clovek(int hmotnost, string jmeno)
        {
            Hmotnost = hmotnost;
            Jmeno = jmeno;
        }
    }
}
