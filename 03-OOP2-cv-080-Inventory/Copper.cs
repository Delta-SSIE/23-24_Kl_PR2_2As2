using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Copper : Coin
    {
        public override int Value { get => 1;}
        public Copper(int count = 1) : base("Copper coin", 1, count)
        {
        }
    }
}
