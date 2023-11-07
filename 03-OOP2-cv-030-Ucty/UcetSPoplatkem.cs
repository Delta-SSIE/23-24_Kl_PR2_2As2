using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_030_Ucty
{
    internal class UcetSPoplatkem : Ucet
    {
        public double PoplatekZaVklad { get; set; }
        public double PoplatekZaVyber { get; set; }

        public override void Uloz(double ulozka)
        {
            ulozka -= PoplatekZaVklad;
            base.Uloz(ulozka);
        }
        public override void Vyber(double castka)
        {
            castka += PoplatekZaVyber;
            base.Vyber(castka);
        }
    }
}
