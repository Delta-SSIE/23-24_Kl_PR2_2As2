namespace _01_OOP_051_Lanovka_ukazatele
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lanovka lanovka = new Lanovka(4, 250);

            Clovek pepa = new Clovek(80, "Pepa");
            Clovek franta = new Clovek(60, "Franta");
            Clovek lojza = new Clovek(120, "Lojza");

            Console.WriteLine(lanovka.Nastup(pepa));
            lanovka.Jed();
        }
    }
}
