namespace _03_OOP3_06_Hanojska_vez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Puzzle puzzle = new Puzzle(5);
            puzzle.Render();
            Console.WriteLine();
            
            puzzle.Solve();

            Console.Clear();
            puzzle.Render();
            Console.WriteLine();

            //puzzle.Move(0, 2);
            //puzzle.Render();
            //puzzle.Move(0, 1);
            //puzzle.Render();
            //puzzle.Move(2, 1);
            //puzzle.Render();
            //puzzle.Move(0, 2);
            //puzzle.Render();

        }
    }
}
