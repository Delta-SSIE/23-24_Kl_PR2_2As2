using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _03_OOP2_cv_060_Utvary
{
    internal class Kruh : IUtvar
    {
        public string Nazev => "kruh";

        public double Polomer { get; private set; }

        public Kruh(double polomer)
        {
            Polomer = polomer;
        }

        public double GetObsah()
        {
            return Math.PI * Polomer * Polomer;
        }

        public double GetObvod()
        {
            return 2 * Math.PI * Polomer;
        }
        public override string ToString()
        {
            return $"Kruh o poloměru {Polomer} cm";
        }
    }
}
