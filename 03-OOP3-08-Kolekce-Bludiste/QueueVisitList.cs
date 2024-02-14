using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class QueueVisitList : IVisitList
    {
        private Queue<Coords> queue = new Queue<Coords>();

        public int Count => queue.Count;

        public void AddPlace(Coords place)
        {
            queue.Enqueue(place);
        }

        public Coords GetPlace()
        {
            return queue.Dequeue();
        }
    }
}
