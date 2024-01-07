using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_060_Utvary
{
    internal class Ctverec : IUtvar
    {
        public string Nazev => "čtverec";

        public double Strana { get; private set; }

        public Ctverec(double strana)
        {
            Strana = strana;
        }

        public double GetObsah()
        {
            return Strana * Strana;
        }

        public double GetObvod()
        {
            return 4 * Strana;
        }

        public override string ToString()
        {
            return $"Čtverec o straně {Strana} cm";
        }
    }
}
