﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_030_Ucty
{
    internal class SporiciUcet :  Ucet
    {
        public double UrokovaMira { get; set; }

        public void Urokuj()
        {
            Stav += Stav * UrokovaMira / 100;
        }
    }
}
