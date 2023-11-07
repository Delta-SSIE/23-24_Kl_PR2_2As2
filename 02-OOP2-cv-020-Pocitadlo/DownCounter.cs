using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_cv_020_Pocitadlo
{
    internal class DownCounter : StepCounter
    {
        public int InitValue { get; private set; }
        //public bool IsFinished
        //{
        //    get
        //    {
        //        return Count <= 0;
        //    }
        //}
        public bool IsFinished => Count <= 0;

        public DownCounter(int step, int initValue) : base(-step)
        {
            InitValue = initValue;
            Count = InitValue;
        }

        public override void Reset()
        {
            Count = InitValue;
        }
    }
}
