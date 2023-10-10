using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_040_Test_vyrobku
{
    internal class Tester
    {
		private Vyrobek _vzor;

		public Vyrobek Vzor
		{
			get { return _vzor; }
			set {
				if (value == null)
                    throw new ArgumentNullException();

				_vzor = value; 
			}
		}

		private double _tolerance;

		/// <summary>
		/// Označuje toleranci v procentech
		/// </summary>
		public double Tolerance
		{
			get { return _tolerance; }
			set {
				if (value <= 0)
					throw new ArgumentOutOfRangeException();

				_tolerance = value; 
			}
		}
        /// <summary>
        /// Vytvoří novou testovácí třídu
        /// </summary>
        /// <param name="vzor">Vzorový výrobek, se kterým se bude porovnávat</param>
        /// <param name="tolerance">Tolerance v procentech</param>
        public Tester(Vyrobek vzor, double tolerance)
        {
            Vzor = vzor;
            Tolerance = tolerance;
        }

		public bool Vyhovuje(Vyrobek vyrobek)
		{
			// o kolik se liší v procentech
			double odchylka = (vyrobek.Rozmer - Vzor.Rozmer) / Vzor.Rozmer * 100;
			
			//odpovím porovnáním s tolerancí
			if (Math.Abs(odchylka) > Tolerance)
				return false;
			else
				return true;
		}
    }
}
