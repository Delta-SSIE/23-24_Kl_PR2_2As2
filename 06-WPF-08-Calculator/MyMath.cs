using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_WPF_08_Calculator
{
    internal static class MyMath
    {
        public static double Add(double num1, double num2) => num1 + num2;
        public static double Subtract(double num1, double num2) => num1 - num2;
        public static double Multiply(double num1, double num2) => num1 * num2;
        public static double Divide(double num1, double num2) => num1 / num2;
        public static double Percent(double num) => num / 100;         
    }
}
