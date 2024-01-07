using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_040_Zamestanci
{
//    Abstraktní třída

//s vlastnostmi Jmeno, Prijmeni(řetězce), které lze veřejně číst, ale nastavit je může jen konstruktor
//s konstruktorem, kterému se Jmeno a Prijmeni předávají
//s abstraktní metodou Mzda() (celé číslo)
    internal abstract class Zamestnanec
    {
        public string Jmeno { get; init; }
        public string Prijmeni { get; init; }

        protected Zamestnanec(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        public abstract int Mzda();
    }
}
