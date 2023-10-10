using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_OOP_052_Lanovka_Spojovy_seznam
{
    internal class Lanovka
    {
        private Sedacka _dolni;
        private Sedacka _horni;
        public int Delka { get; init; }
        public int Nosnost { get; init; }
        public bool JeVolnoDole => _dolni.Pasazer == null;
        public bool JeVolnoNahore => _horni.Pasazer == null;

        public int Zatizeni
        {
            get
            {
                int celkem = 0;

                Sedacka tahle = _horni;
                do
                {
                    if (tahle.Pasazer != null)
                        celkem += tahle.Pasazer.Hmotnost;

                    tahle = tahle.Nizsi;
                }
                while (tahle != null);

                return celkem;
            }
        }
        public Lanovka(int delka, int nosnost)
        {
            Delka = delka;
            Nosnost = nosnost;

            //sestavit celou lanovku
            _horni = new Sedacka();
            Sedacka posledniVyrobena = _horni;

            for (int i = 0; i < delka - 1; i++)
            {
                Sedacka tahle = new Sedacka();
                posledniVyrobena.Nizsi = tahle;

                posledniVyrobena = tahle;
            }

            _dolni = posledniVyrobena;
        }
        public bool Nastup(Clovek clovek)
        {
            if (!JeVolnoDole)
                return false;

            if (Zatizeni + clovek.Hmotnost > Nosnost)
                return false;

            _dolni.Pasazer = clovek;
            return true;
        }
        public Clovek Vystup()
        {
            Clovek pasazer = _horni.Pasazer;
            _horni.Pasazer = null;
            return pasazer;
        }
        public void Jed()
        {
            Sedacka presun = _horni;

            _horni = _horni.Nizsi; //nová nejvyšší bude tak, která byla pod současnou
            _dolni.Nizsi = presun; //pod bývalou nejnižší bude připojena přesouvaná
            presun.Nizsi = null; //nová nejnižší nemá pod sebou nikoho

            _dolni = presun; //zapamatuju si, která je nová nejnižší
        }
    }
            
}
