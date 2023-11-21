namespace _03_OOP2_cv_060_Utvary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtvar[] utvary =
            {
                new Ctverec(4),
                new Ctverec(1),
                new Kruh(2)
            };

            double obvod = 0;
            double obsah = 0;
            foreach (IUtvar utvar in utvary)
            {
                Console.WriteLine(utvar.ToString());
                obvod += utvar.GetObvod();
                obsah += utvar.GetObsah();
            }
            Console.WriteLine($"Celkový obvod je {obvod:0.00} cm a obsah je {obsah:0.00} cm2.");

            PlechovkaBarvy pixla = new PlechovkaBarvy(60, 3);
            foreach (IUtvar utvar in utvary)
            {
                if (pixla.Obarvi(utvar))
                {
                    Console.WriteLine($"Obarvili jsme {utvar}");
                    Console.WriteLine($"Zbývá {pixla} ");
                }
                else
                {
                    Console.WriteLine($"Nelze obarvit {utvar}");
                }
            }
        }
    }
}
