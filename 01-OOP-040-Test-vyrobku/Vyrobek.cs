using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_040_Test_vyrobku
{
    internal class Vyrobek
    {
		private double _rozmer;

		public double Rozmer
		{
			get { return _rozmer; }
			set 
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException();

				_rozmer = value; 
			}
		}

        public Vyrobek(double rozmer)
        {
            Rozmer = rozmer;
        }
    }
}
