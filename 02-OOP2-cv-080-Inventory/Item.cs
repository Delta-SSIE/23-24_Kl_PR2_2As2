using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Item
    {
        public string Name { get; protected set;}
        public virtual double Weight { get; protected set; }

        public Item(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        protected Item()
        {
        }

        public virtual string Description()
        {
            return Name;
        }
    }
}
