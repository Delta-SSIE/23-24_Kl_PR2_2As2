namespace _02_OOP2_030_Abstraktni_savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kun ferda = new Kun("Ferda");
            //ferda.Cvalej();
            //ferda.Dychej();
            //ferda.SajMleko();
            //ferda.Jmeno = "Karel"; //nelze - je chráněno

            //Savec[] savci = new Savec[3];
            //savci[0] = new Kun("Ferda");
            //savci[1] = new Kun("Kobyl");
            //savci[2] = new Velryba("Charles");

            //foreach (Savec savec in savci)
            //{
            //    savec.PredstavSe();
            //}

            //Savec kuliferda = new Savec();// abstraktní třída nesmí mít instanci

        }
    }
    abstract class Savec //bázová třída ... to společné
    {
        protected string Jmeno { get; set; } //i dědící třídy mohou vidět/měnit
        public Savec(string jmeno)
        {
            Jmeno = jmeno;
        }
        public void Dychej()
        {
            Console.WriteLine("Nádech - výdech");
        }
        public void SajMleko()
        {
            Console.WriteLine("... ... ...");
        }
        public abstract void PredstavSe();
    }

    class Kun : Savec //odvozená třída ... to, čím se liší od bázové
    {
        public Kun(string jmeno) : base(jmeno)
        {
        }
        public void Cvalej()
        {
            Console.WriteLine("Kopyta pádí");
        }
        //public override void PredstavSe()
        //{
        //    Console.WriteLine($"Já jsem {Jmeno}, íhahá");
        //    //jméno je dostupné, i když kód není přímo ve třídě savec.
        //    //Protected připouští i dědící třídu
        //}
    }

    class Velryba : Savec
    {
        public Velryba(string jmeno) : base(jmeno)
        {
        }

        public void Plav()
        {
            Console.WriteLine("Šplouch");
        }

        public override void PredstavSe()
        {
            Console.WriteLine($"Já jsem {Jmeno}, šplouch a huí");
            //jméno je dostupné, i když kód není přímo ve třídě savec.
            //Protected připouští i dědící třídu
        }
    }
}
