namespace _02_OOP2_010_Savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kun ferda = new Kun();
            ferda.Cvalej();
            ferda.Dychej();
            ferda.SajMleko();

            Velryba mobyDick = new Velryba();
            mobyDick.Plav();
            mobyDick.Dychej();
            mobyDick.SajMleko();

            //mobyDick.Cvalej();

            Savec konik = new Kun(); //lze, kun je savec
            //konik.Cvalej(); //nechce, protože třída Savec nemá metodu cvalej

            Kun kopieKone = (Kun)konik;
            kopieKone.Cvalej();

            Savec kopieVelryby = mobyDick;
            // Kun krizenec = (Kun)kopieVelryby; //nelze uvnitř je velryba, velryba není kůň
            // krizenec.Cvalej();
        }
    }

    class Savec //bázová třída ... to společné
    {
        public void Dychej()
        {
            Console.WriteLine("Nádech - výdech");
        }
        public void SajMleko()
        {
            Console.WriteLine("... ... ...");
        }
    }

    class Kun : Savec //odvozená třída ... to, čím se liší od bázové
    {
        public void Cvalej()
        {
            Console.WriteLine("Kopyta pádí");
        }
    }

    class Velryba : Savec
    {
        public void Plav()
        {
            Console.WriteLine("Šplouch");
        }
    }
}
