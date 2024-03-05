using Microsoft.VisualStudio.TestTools.UnitTesting;
using _03_OOP3_12_UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP3_12_UnitTesting.Tests
{
    [TestClass()]
    public class MyClassTests
    {
        [TestMethod()]
        public void ArrayMinBasicTest()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            Assert.AreEqual(1, MyClass.ArrayMin(nums));
        }

        [TestMethod()]
        public void ArrayMinNegativeTest()
        {
            int[] nums = { -1, -2, -3, -4, -5 };
            Assert.AreEqual(-5, MyClass.ArrayMin(nums));
        }

        [TestMethod()]
        [ExpectedException(typeof(EmptyArrayException))]
        public void EmptyArrayTest()
        {
            int[] nums = new int[0];
            MyClass.ArrayMin(nums);
            //Assert.Fail(); //sem bych se dostat neměl - má jít výjimka
        }
    }
}