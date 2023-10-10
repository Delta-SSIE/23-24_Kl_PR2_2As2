using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_051_Lanovka_ukazatele
{
    internal class Lanovka
    {
        private Clovek[] _sedacky;
        private int _dolniSedacka;
        private int _horniSedacka
        {
            get {
                if (_dolniSedacka > 0)
                    return _dolniSedacka - 1;

                return Delka - 1;
            }
        }
        public int Delka { get; init; }
        public int Nosnost { get; init; }
        public bool JeVolnoDole => _sedacky[_dolniSedacka] == null;
        public bool JeVolnoNahore => _sedacky[_horniSedacka] == null;

        public int Zatizeni
        {
            get
            {
                int zatizeni = 0;
                foreach (Clovek c in _sedacky)
                {
                    if (c != null)
                        zatizeni += c.Hmotnost;
                }
                return zatizeni;

                //return _sedacky.Select(x => x == null ? 0 : x.Hmotnost).Sum();

            }
        }

        public Lanovka(int delka, int nosnost)
        {
            Delka = delka;
            Nosnost = nosnost;

            _sedacky = new Clovek[delka];

        }

        public bool Nastup(Clovek clovek)
        {
            if (!JeVolnoDole)
                return false;

            if (Zatizeni + clovek.Hmotnost > Nosnost)
                return false;

            _sedacky[0] = clovek;
            return true;
        }

        public Clovek Vystup()
        {
            Clovek nahore = _sedacky[_horniSedacka];
            _sedacky[_horniSedacka] = null;
            return nahore;
        }

        public void Jed()
        {
            if (!JeVolnoNahore)
                throw new Exception("Nelze jet s clovekem nahore");

            _dolniSedacka--;

            if (_dolniSedacka < 0) //při přetečení
                _dolniSedacka += Delka;

        }



    }

}
