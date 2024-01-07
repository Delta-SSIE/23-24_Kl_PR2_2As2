using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_DopravniProstredek
{
    public interface IMotorovy
    {
        public TypPohonu Pohon {get; }
        public void Natankuj();
    }
}
