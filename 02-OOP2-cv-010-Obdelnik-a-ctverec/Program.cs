namespace _02_OOP2_cv_010_Obdelnik_a_ctverec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik abcd = new Obdelnik(3, 4.5);
            Console.WriteLine(abcd) ;
            Console.WriteLine($"obsah: {abcd.Obsah()} , obvod: {abcd.Obvod()}");

            Ctverec efgh = new Ctverec(3);
            Console.WriteLine(efgh);
            Console.WriteLine($"obsah: {efgh.Obsah()} , obvod: {efgh.Obvod()}");
        }
    }
}
