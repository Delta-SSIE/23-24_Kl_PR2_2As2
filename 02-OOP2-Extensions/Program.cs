namespace _03_OOP2_Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cislo = 5;
            if (cislo.IsEven())
            {
                Console.WriteLine("číslo je sudé");
            }
            else
            {
                Console.WriteLine("číslo je liché");
            }
        }
    }
}
