using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _03_OOP2_cv_060_Utvary
{
    //Vytvořte třídu PlechovkaBarvy

    //bude v konstruktoru dostávat desetinná čísla objem a vydatnost, která si uloží.Čísla znamenají, kolik mililitrů v "pixle" je a kolik je třeba mililitrů na cm².
    //bude mít veřejnou metodu ToString(), která bude vracet něco jako "Plechovka barvy, zbývá jí ještě na 60 cm²".
    //bude mít veřejnou metodu Obarvi(), která obrdží IUtvar a pokud je v plechovce dost barvy na jeho obarvení, sníží svůj objem a vrátí true (úspěch), jinak si ponechá původní objem a vrátí false (neúspěch)
    //Vytvořte instanci plechovky a vyzkoušejte obarvit všechny útvary z pole.Udělejte si pole větší, abyste vyzkoušeli i to, že plechovka dojde.
    internal class PlechovkaBarvy
    {
        private double _objem;
        private double _vydatnost;

        public PlechovkaBarvy(double objem, double vydatnost)
        {
            _objem = objem;
            _vydatnost = vydatnost;
        }

        public override string ToString()
        {
            return $"Plechovka barvy, zbývá jí ještě na {_objem * _vydatnost} cm2";
        }

        public bool Obarvi(IUtvar utvar)
        {            
            double spotreba = utvar.GetObsah() / _vydatnost; //v mililitrech
            
            if (spotreba > _objem)
                return false;

            _objem -= spotreba;
            return true;
        }

    }
}
