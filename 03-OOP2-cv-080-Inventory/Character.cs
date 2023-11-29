using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Character
    {
        public string Name { get; private set; }
        public double MaxWeight { get; private set; }
        private List<Item> _inventory = new List<Item>();
        private double _carrying = 0;

        public Character(string name, double maxWeight)
        {
            Name = name;
            MaxWeight = maxWeight; //ToDo: error check
        }
        public bool AddItem(Item item)
        {
            // zkontrolovat, jestli unese
            if (_carrying + item.Weight <= MaxWeight)
            {
                //když unese, přidat                
                if (item is StackableItem)                
                    StoreStackableItem((StackableItem)item);
                
                else
                    StoreItem(item);

                _carrying += item.Weight;

                return true;
            }
            //když neunese, varovat
            else
            {
                return false;
            }
        }

        private void StoreItem(Item item)
        {
            _inventory.Add(item);
        }
        private void StoreStackableItem(StackableItem item)
        {
            //najdi, jestli tam je
            foreach (Item i in _inventory)
            {
                StackableItem stored = i as StackableItem;
                if (stored == null)
                    continue;

                //když je, zvyš počet
                if (i.Name == item.Name)
                {
                    stored.ModifyCount(item.Count);
                    return;
                }
            }

            //když není, vlož
            _inventory.Add(item);
            
        }

        public void DropItem(Item item)
        {
            if (_inventory.Contains(item))
            {
                _carrying -= item.Weight;
                _inventory.Remove(item);
            }
        }

        public void DropItem(StackableItem item, int count = 1)
        {
            //ToDo: Drop stackable
        }

        public string ListInventory()
        {
            string output = "";
            foreach (Item i in _inventory)
            {
                output += i.Description() + "\n";
            }
            return output;            
        }
    }
}
