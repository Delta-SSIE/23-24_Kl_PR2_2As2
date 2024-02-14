using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal interface IVisitList
    {
        int Count { get; }
        void AddPlace(Coords place);
        Coords GetPlace();
    }
}
