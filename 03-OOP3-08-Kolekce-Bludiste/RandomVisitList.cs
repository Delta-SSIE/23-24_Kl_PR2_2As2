using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class RandomVisitList : IVisitList
    {
        private List<Coords> list = new();
        private Random random = new Random();

        public int Count => list.Count;

        public void AddPlace(Coords place)
        {
            list.Add(place);
        }

        public Coords GetPlace()
        {
            int index = random.Next(list.Count);
            Coords result = list[index];
            list.RemoveAt(index);
            return result;
        }
    }
}
