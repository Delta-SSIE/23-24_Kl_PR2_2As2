using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_Extensions
{
    internal static class Utils
    {
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }
    }
}
