using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_cv_010_Obdelnik_a_ctverec
{
    internal class Obdelnik
    {
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }

        public Obdelnik(double stranaA, double stranaB)
        {
            if (stranaA < 0)
                throw new ArgumentOutOfRangeException();
            StranaA = stranaA;

            if (stranaB < 0)
                throw new ArgumentOutOfRangeException();
            StranaB = stranaB;
        }
        public double Obvod()
        {
            return 2 * (StranaA + StranaB);
        }
        public double Obsah()
        {
            return StranaA * StranaB;
        }
        public override string ToString()
        {
            return $"Obdélník o stranách {StranaA} a {StranaB}";
        }
    }
}
