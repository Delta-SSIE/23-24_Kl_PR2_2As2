using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_cv_020_Pocitadlo
{
    internal class StepCounter : Counter
    {
        private int _step;

        public StepCounter(int step)
        {
            this._step = step;
        }

        public override void Next()
        {
            Count += _step;
        }
    }
}
