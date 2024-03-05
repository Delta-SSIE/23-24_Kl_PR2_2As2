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
    public class RychlostniSkrinTests
    {
        [TestMethod()]
        public void RychlostniSkrinInitDataTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            Assert.AreEqual(1500, rs.MaxOtackyProRazeni);
        }

        [TestMethod()]
        public void RychlostniSkrinNeutralTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            Assert.AreEqual(Stupen.Neutral, rs.Zarazeno);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RychlostniSkrinNegativeTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(-1500);
            Assert.Fail();
        }

        [TestMethod()]
        public void NahoruTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            for (int i = 0; i < 5; i++)
            {
                rs.Nahoru();
            }
            Assert.AreEqual(Stupen.Pet, rs.Zarazeno);
        }
        [TestMethod()]
        public void AzNahoruTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            for (int i = 0; i < 6; i++)
            {
                rs.Nahoru();
            }
            Assert.AreEqual(Stupen.Pet, rs.Zarazeno);
        }
        [TestMethod()]
        public void DoluTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Dolu();
            Assert.AreEqual(Stupen.Zpatecka, rs.Zarazeno);
        }
        [TestMethod()]
        public void AzDoluTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Dolu();
            rs.Dolu();
            Assert.AreEqual(Stupen.Zpatecka, rs.Zarazeno);
        }
        [TestMethod()]
        public void NahoruTooFastTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Otacky = 1600;
            rs.Nahoru();
            Assert.AreEqual(Stupen.Neutral, rs.Zarazeno);
        }
        [TestMethod()]
        public void DoluTooFastTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Otacky = 1600;
            rs.Dolu();
            Assert.AreEqual(Stupen.Neutral, rs.Zarazeno);
        }
        [TestMethod()]
        public void OtackySetTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Otacky = 1600;
            Assert.AreEqual(1600, rs.Otacky);
        }
        [TestMethod()]
        [ExpectedException (typeof(ArgumentOutOfRangeException))]
        public void OtackySetNegativeTest()
        {
            RychlostniSkrin rs = new RychlostniSkrin(1500);
            rs.Otacky = -1600;
        }

    }
}