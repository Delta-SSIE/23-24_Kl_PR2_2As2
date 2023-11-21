namespace _03_OOP2_DopravniProstredek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Motocykl babeta = new Motocykl(40);
            IPojizdny babeta2 = babeta;

            
            
            IPojizdny[] jezditka = new IPojizdny[2];
            jezditka[0] = babeta;
            jezditka[1] = new Kocarek(4);

            int celkemKolecka = 0;
            foreach (IPojizdny vec in jezditka)
            {
                celkemKolecka += vec.PocetKol;
            }
            Console.WriteLine($"celkem je tu {celkemKolecka} kol");
        }
    }
}
