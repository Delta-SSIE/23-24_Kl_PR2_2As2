using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_060_Utvary
{
    //Založte interface IUtvar. IUtvar bude mít:

    //vlastnost Nazev(string) veřejně pro čtení
    //veřejné metody GetObvod() a GetObsah() (vrací double)
    internal interface IUtvar
    {
        public string Nazev { get; }
        public double GetObvod();
        public double GetObsah();

    }
}
