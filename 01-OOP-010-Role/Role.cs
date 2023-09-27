using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_010_Role
{

    //internal class Role
    //{
    //    public string Barva;
    //    public double Delka;

    //    public Role(string barva, double delka)
    //    {
    //        Barva = barva;
    //        Delka = delka;
    //    }

    //    public override string ToString()
    //    {
    //        return $"Role papíru, barva {Barva}, zbývá {Delka} cm.";
    //    }
    //}

    internal class Role
    {
        private string _barva;

        public string Barva { get; private set; }
        //public string Barva
        //{
        //    get
        //    {
        //        return _barva;
        //    }
        //    set
        //    {
        //        //_barva = value; //takhle bez kontroly

        //        //zkontroluju hodnotu
        //        if (value != "červená" && value != "modrá")
        //            throw new ArgumentException();

        //        _barva = value; //uložím předanou hodnotu
        //    }
        //}

        private double _delka;

        public double Delka
        {
            get { return _delka; }
            set 
            {
                if (value < 0) //neplatná hodnota délky
                    throw new ArgumentOutOfRangeException();

                _delka = value; //prošel kontrolou - uložím
            }
        }


        public Role(string barva, double delka)
        {
            Barva = barva;
            Delka = delka;
        }

        public override string ToString()
        {
            return $"Role papíru, barva {Barva}, zbývá {Delka} cm.";
        }

        

    }
}
