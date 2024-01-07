using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Weapon : Item
    {
        public int Attack { get; init; }
        public Weapon(string name, double weight, int attack) : base(name, weight)
        {
            Attack = attack;
        }
    }
}
