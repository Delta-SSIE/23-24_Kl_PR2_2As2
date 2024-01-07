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

        public int HP { get; private set; }
        public int MaxHP { get; private set; }

        public Weapon RightHand { get; private set; }
        public Shield LeftHand { get; private set; }
        public Armor Wearing { get; private set; }

        public int Balance
        {
            get
            {
                int balance = 0;
                foreach (Item item in _inventory)
                {
                    Coin coin = item as Coin;
                    if (coin == null)
                        continue;

                    balance += coin.Value * coin.Count;
                }
                return balance;
            }
        }

        private Dice _dice = new Dice(6);

        public Character(string name, double maxWeight, int maxHP)
        {
            Name = name;
            MaxWeight = maxWeight; //ToDo: error check
            MaxHP = HP = maxHP;
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
            else
                throw new ArgumentException("Cannot drop item - does not have it");
        }

        public void DropItem(StackableItem item, int count = 1)
        {
            
            foreach (Item i in _inventory)
            {
                StackableItem stored = i as StackableItem;
                if (stored == null)
                    continue;

                //když je, sniž počet
                if (stored.Name == item.Name)
                {
                    if (stored.Count < count) //tolik jich nemám
                        throw new ArgumentException("Cannot drop items - does not have enough");

                    else if (stored.Count == count)
                    { 
                        _inventory.Remove(stored);
                        _carrying -= stored.Weight; //odstraňuju vše - celou váhu vyhodím
                        return;
                    }
                    else
                    { 
                        stored.ModifyCount(-count);
                        _carrying -= count * item.SingleItemWeight;
                        return;
                    }
                }
            }

            //sem přijdu, když v inventáři není
            throw new ArgumentException("Cannot drop item - does not have it");
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

        public void Equip(Item item)
        {
            if (!_inventory.Contains(item))
                throw new Exception($"Cannot equip {item.Name}, not holding it");

            if (item is Weapon weapon)
            {
                if (RightHand != null)
                    _inventory.Add(RightHand);

                RightHand = weapon;
                _inventory.Remove(weapon);
            }
            else if (item is Shield shield)
            {
                if (LeftHand != null)
                    _inventory.Add(LeftHand);

                LeftHand = shield;
                _inventory.Remove(item);
            }
            else if (item is Armor armor)
            {
                if (Wearing != null)
                    _inventory.Add(Wearing);

                Wearing = armor;
                _inventory.Remove(item);
            }
            else
            {
                throw new Exception($"Cannot equip {item.Name}");
            }
        }

        public void Unequip(Item item)
        {
            if (RightHand == item)
            {
                RightHand = null;
                _inventory.Add(item);
            }
            else if (LeftHand == item)
            {
                LeftHand = null;
                _inventory.Add(item);
            }
            else if (Wearing == item)
            {
                Wearing = null;
                _inventory.Add(item);
            }

        }

        public int Attack()
        {
            if (RightHand == null) //prázdná ruka má útok 0
                return _dice.Throw();

            return RightHand.Attack + _dice.Throw();
        }

        private int Defend()
        {
            int defense = 0;
            
            if (LeftHand != null)
                defense += LeftHand.Defense;

            if (Wearing != null)
                defense += Wearing.Defense;

            defense += _dice.Throw();

            return defense;
        }

        public int ManageAttack(int attack)
        {
            int defense = this.Defend();
            int wound = Math.Max(0, attack - defense); //abych úderem neléčil
            
            HP -= wound;
            if (HP < 0)
                HP = 0;

            return wound;
        }
    }
}
