using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_DopravniProstredek
{
    public enum TypPohonu { Manualni, SpalovaciMotor, Elektromotor }
    abstract class DopravniProstredek
    {
        public string Nazev { get; protected set; }
        public double MaxRychlost { get; protected set; }
        public int PocetMist { get; protected set; }

        public TypPohonu Pohon { get; protected set; }

        protected DopravniProstredek(string nazev, double maxRychlost, int pocetMist, TypPohonu pohon)
        {
            Nazev = nazev;
            MaxRychlost = maxRychlost;
            PocetMist = pocetMist;
            Pohon = pohon;
        }

        public abstract void Natankuj();
    }
    

}
