using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_040_Zamestanci
{
    //Dobrovolnik
    //Dědí ze třídy Zamestnanec
    //Jeho mzda je nulová
    internal class Dobrovolnik : Zamestnanec
    {
        public Dobrovolnik(string jmeno, string prijmeni) : base(jmeno, prijmeni) {}

        public override int Mzda()
        {
            return 0;
        }
    }
}
