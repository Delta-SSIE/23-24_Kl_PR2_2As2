using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class PlaceStack : IVisitList
    {
        private Stack<Coords> _places = new Stack<Coords>();

        public int Count => _places.Count;

        public void AddPlace(Coords coords)
        {
            _places.Push(coords);
        }

        public Coords GetNextPlace()
        {
            return _places.Pop();
        }
    }
}
