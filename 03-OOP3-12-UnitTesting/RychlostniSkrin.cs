using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP3_12_UnitTesting
{
    public enum Stupen { Zpatecka, Neutral, Jedna, Dva, Tri, Ctyri, Pet}
    public class RychlostniSkrin
    {
        public int MaxOtackyProRazeni { get; init; }
        public Stupen Zarazeno { get; private set; }

        private int otacky;
        public int Otacky {
            get => otacky; 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();

                otacky = value;
            }
        }

        public RychlostniSkrin(int maxOtackyProRazeni)
        {
            if (maxOtackyProRazeni < 0)
                throw new ArgumentOutOfRangeException();

            MaxOtackyProRazeni = maxOtackyProRazeni;
            Zarazeno = Stupen.Neutral;
        }

        public void Nahoru()
        {
            if (Zarazeno != Stupen.Pet && otacky <= MaxOtackyProRazeni)
                Zarazeno += 1;
        }

        public void Dolu()
        {
            if (Zarazeno > Stupen.Zpatecka && otacky <= MaxOtackyProRazeni)
                Zarazeno -= 1;
        }
    }
}
