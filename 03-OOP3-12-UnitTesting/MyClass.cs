using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP3_12_UnitTesting
{
    public class MyClass
    {
        public static int ArrayMin(int[] numbers)
        {
            if (numbers.Length == 0)
                throw new EmptyArrayException();

            int min = int.MaxValue;
            foreach(int number in numbers)
            {
                if (min > number)
                    min = number;
            }
            return min;
        }
    }
}
