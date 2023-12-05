using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Gold : Coin
    {
        public override int Value { get => 100; }
        public Gold(int count = 1) : base("Gold coin", 1, count)
        {
        }
    }
}
