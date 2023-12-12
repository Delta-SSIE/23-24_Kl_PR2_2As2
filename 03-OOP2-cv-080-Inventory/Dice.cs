using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Dice
    {
        public int Sides { get; init; }
        private static Random _rnd = null;
        public Dice(int sides)
        {
            if (_rnd == null)
                _rnd = new Random();

            Sides = sides;
        }
        public int Throw()
        {
            return _rnd.Next(1, Sides + 1);
        }
    }
}
