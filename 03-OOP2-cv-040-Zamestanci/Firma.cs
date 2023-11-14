using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_040_Zamestanci
{
    //Firma
    //Má veřejné metody Zamestnej(zamestnanec) a Propust(zamestnanec), kterým předáme instanci nějakého zaměstnance a firma si jej připíše na svůj seznam. (Nápověda: použijte List - nebo by se hodil HashSet, ale ten si musíte dohledat)
    //Má veřejnou metodu Vyplata, která vypíše pod sebe na řádky všechny zaměstnance spolu s částkou, která jim bude vyplacena a pod to napíše celkovou sumu výplat.
    internal class Firma
    {
        private List<Zamestnanec> _personal = new List<Zamestnanec>();
        public void Zamestnej(Zamestnanec osoba)
        {
            if (!_personal.Contains(osoba))
                _personal.Add(osoba);
        }
        public void Propust(Zamestnanec osoba)
        {
            _personal.Remove(osoba);
        }
        public void Vyplata()
        {
            int celkem = 0;

            foreach (Zamestnanec zamestnanec in _personal)
            {
                int mzda = zamestnanec.Mzda();
                celkem += mzda;
                Console.WriteLine($"{zamestnanec.Prijmeni} {zamestnanec.Jmeno}: {mzda:0.00} Kč");
            }

            Console.WriteLine($"Celkem: {celkem:0.00} Kč");
        }
    }
}
