using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP3_06_Hanojska_vez
{
    internal class Puzzle
    {
        public int Size { get; private set; }
        public string ErrorMessage { get; private set; }

        private Stack<int> leftTower = new Stack<int>();
        private Stack<int> middleTower = new Stack<int>();
        private Stack<int> rightTower = new Stack<int>();

        public bool IsSolved => rightTower.Count == Size; //vše je vpravo

        public Puzzle(int size)
        {
            Size = size;

            //naplním levou věž disky
            for (int disc = size; disc > 0; disc--)
            {
                leftTower.Push(disc);
            }
        }

        public bool Move(int from, int to)
        {
            try 
            { 
                Stack<int> fromTower = GetTower(from);
                Stack<int> toTower = GetTower(to);
                return Move(fromTower, toTower);
            }
            catch
            {
                return false;
            }
        }

        private bool Move(Stack<int> from, Stack<int> to)
        {
            //není náhodou from a to stejné
            if (from == to) 
            {
                ErrorMessage = "Same tower from and to";
                return false;
            }

            //zjisti, jestli je co brát
            if (from.Count < 1)
            {
                ErrorMessage = "Source tower is empty";
                return false;
            }


            //zjisti, jestli nedáváš na menší
            if (to.Count > 0 && (from.Peek() > to.Peek()))
            {
                ErrorMessage = "Cannot put a larger disc on a smaller one";
                return false;
            }

            //udělej to
            int disc = from.Pop();
            to.Push(disc);
            ErrorMessage = string.Empty;
            return true;
        }

        private Stack<int> GetTower(int number)
        {
            return number switch
            {
                0 => leftTower,
                1 => middleTower,
                2 => rightTower,
                _ => throw new ArgumentOutOfRangeException(nameof(number)),
            };
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + ": ");
                RenderTower(i);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void RenderTower(int number)
        {
            //Stack<int> tower = GetTower(number);
            //foreach(int disc in tower)
            //{
            //    Console.Write(disc + " ");
            //}
            
            int[] discs = GetTower(number).ToArray();
            Array.Reverse(discs);
            Console.Write(string.Join(" ", discs));

            //for (int i = discs.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(discs[i] + " ");
            //}
        }
    }
}
