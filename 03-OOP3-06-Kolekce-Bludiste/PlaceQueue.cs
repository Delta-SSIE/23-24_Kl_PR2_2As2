using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class PlaceQueue : IVisitList
    {
        private Queue<Coords> _places = new Queue<Coords>();

        public int Count => _places.Count;

        public void AddPlace(Coords coords)
        {
            _places.Enqueue(coords);
        }

        public Coords GetNextPlace()
        {
            return _places.Dequeue();
        }
    }
}
