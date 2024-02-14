using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class StackVisitList : IVisitList
    {
        private Stack<Coords> stack = new Stack<Coords>();
        
        public int Count => stack.Count;

        public void AddPlace(Coords place)
        {
            stack.Push(place);
        }

        public Coords GetPlace()
        {
            return stack.Pop();
        }
    }
}
