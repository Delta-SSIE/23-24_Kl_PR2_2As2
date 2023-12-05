using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal abstract class Coin : StackableItem
    {
        public virtual int Value { get; }

        protected Coin(string name, double weight, int count = 1) : base(name, weight, count)
        {

        }

    }
}
