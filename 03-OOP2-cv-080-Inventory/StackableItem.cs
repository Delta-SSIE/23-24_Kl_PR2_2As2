using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class StackableItem : Item
    {
        private double _singleItemWeight;
        public StackableItem(string name, double weight, int count = 1)
        {
            _singleItemWeight = weight;
            Name = name;
            Count = count;
        }

        public int Count { get; private set; }

        public override double Weight 
        {
            get
            {
                return Count * _singleItemWeight;
            }
        }

        public override string Description()
        {
            return $"{Name} ({Count}x)";
        }

        public void ModifyCount(int count)
        {
            Count += count;
        }
    }
}
