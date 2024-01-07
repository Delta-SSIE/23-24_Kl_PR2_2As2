using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_030_Ucty
{
    internal class Ucet
    {
        public double Stav { get; protected set; }
        public virtual void Uloz(double ulozka)
        {
            if (ulozka < 0)
                throw new ArgumentOutOfRangeException();

            Stav += ulozka;
        }
        public virtual void Vyber(double castka)
        {
            if (castka < 0)
                throw new ArgumentOutOfRangeException();

            if (castka > Stav)
                throw new Exception("Pokus o výběr pod zůstatek účtu");

            Stav -= castka;
        }
    }
}
