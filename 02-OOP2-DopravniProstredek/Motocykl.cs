using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_DopravniProstredek
{
    internal class Motocykl : DopravniProstredek, IPojizdny, IMotorovy
    {
        public Motocykl(double maxRychlost) : base("Motocykl", maxRychlost, 2, TypPohonu.SpalovaciMotor)
        {}

        public int PocetKol => 2;

        public override void Natankuj()
        {
            Console.WriteLine("Plním nádrž benzínem");
        }
    }
}
