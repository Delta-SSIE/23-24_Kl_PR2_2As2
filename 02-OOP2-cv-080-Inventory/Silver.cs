using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Silver : Coin
    {
        public override int Value { get => 10; }
        public Silver(int count = 1) : base("Silver coin", 1, count)
        {
        }
    }
}
