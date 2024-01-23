namespace _03_OOP3_04_Fronta_urad
{
    class Program
    {
        public static void Main(string[] args)
        {

            int pocetPrepazek = 3;

            Clovek[] lide =
            {
                new Clovek("Josef", "Smutný", 4),
                new Clovek("Anna", "Veselá", 3),
                new Clovek("Marie", "Zelená", 12),
                new Clovek("Jiří", "Červenka", 3),
                new Clovek("Antonín", "Černý", 5),
                new Clovek("Antonie", "Bohatá", 7),
                new Clovek("Richard", "Těsný", 4),
                new Clovek("Luisa", "Podhorská", 15),
            };

            Prepazka[] prepazky = new Prepazka[pocetPrepazek];
            for (int i = 0; i < pocetPrepazek; i++)
            {
                prepazky[i] = new Prepazka(i + 1);
            }

            Queue<Clovek> fronta = new Queue<Clovek>(lide);
            int cas = 0;

            while(fronta.Count > 0) //dokud je někdo ve frontě
            {
                foreach (Prepazka p in prepazky)
                {
                    if (p.KdyBudeVolna <= cas) //je volná
                    {
                        Clovek c = fronta.Dequeue(); //vezmu prvního z fronty
                        p.VyridZakaznika(c, cas); //předám ho přepážce                       
                    }
                    if (fronta.Count == 0) //když ve frontě už nikdo není
                        break; //skonči procházení přepážek
                }
                cas++;
            }
        }
    }

    class Clovek
    {
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public int Trvani { get; private set; }

        public Clovek(string jmeno, string prijmeni, int trvani)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Trvani = trvani;
        }
    }

    class Prepazka
    {
        public int Cislo { get; private set; }
        public int KdyBudeVolna { get; private set; }

        public void VyridZakaznika(Clovek zakaznik, int cas)
        {
            KdyBudeVolna = cas + zakaznik.Trvani;
            Console.WriteLine($"Přepážka {Cislo}: {zakaznik.Jmeno} {zakaznik.Prijmeni} : {cas}-{KdyBudeVolna - 1}");
        }

        public Prepazka(int cislo)
        {
            Cislo = cislo;
            KdyBudeVolna = 0;
        }
    }
}
