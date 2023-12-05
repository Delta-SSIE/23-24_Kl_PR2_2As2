using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Shield : Item
    {
        public int Defense { get; init; }
        public Shield(string name, double weight, int defense) : base(name, weight)
        {
            Defense = defense;
        }
    }
}

