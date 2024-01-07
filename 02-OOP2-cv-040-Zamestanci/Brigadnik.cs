using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_040_Zamestanci
{
    //Brigadnik
    //Dědí ze třídy Zamestnanec
    //Má veřejné vlastnosti Odpracovano(celé číslo, počet odpracovaných hodin) a HodinovaMzda(celé číslo)
    //Mzda() vrací mzdu vypočtenou z předchozích položek
    internal class Brigadnik : Zamestnanec
    {
        /// <summary>
        /// Počet hodin odpracovaných v měsíci
        /// </summary>
        public int Odpracovano { get; set; }
        public int HodinovaMzda { get; set; }
        public Brigadnik(string jmeno, string prijmeni) : base(jmeno, prijmeni) {}

        public override int Mzda()
        {
            return Odpracovano * HodinovaMzda;
        }
    }
}
