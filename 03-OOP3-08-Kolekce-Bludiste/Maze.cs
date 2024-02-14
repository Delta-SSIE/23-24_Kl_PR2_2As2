using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    internal class Maze
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private Coords _entrance;
        private TileType[,] _map = null;
        private MazeDisplay _display = null;

        public void LoadMaze(string filename)
        {
            using (StreamReader reader = new StreamReader(filename)) //načtu textový soubor
            {
                Width = int.Parse(reader.ReadLine()); //první řádek je šířka
                Height = int.Parse(reader.ReadLine()); //druhý řádek je výška
                
                _map = new TileType[Width, Height];

                string line;
                for (int y = 0; y < Height; y++) //projdu všechny řádky
                {
                    line = reader.ReadLine();
                    for (int x = 0; x < Width; x++) //projdu všechny sloupce
                    {
                        _map[x, y] = line[x] switch //uložím do mapy
                        {
                            '#' => TileType.Wall,
                            ' ' => TileType.Corridor,
                            'S' => TileType.Entrance,
                            'E' => TileType.Exit,
                        };
                        if (line[x] == 'S') //poznamenám si, kde je start
                            _entrance = new Coords(x, y);
                    }
                }                
            }
            _display = new MazeDisplay(1, 1, Width, Height); //připravím prostor pro kreslení, odsazený o 1 čtverec
            RenderMaze();
        }

        public void RenderMaze()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _display.RenderTile(new Coords(x, y), _map[x, y]);
                }
            }
            _display.WrapUp();
        }

        public void Solve(IVisitList visitList)
        {

            //předá mi si seznam míst k projití
            

            //začni na vstupu
            visitList.AddPlace(_entrance);

            //postupně procházej všechna místa
            while (visitList.Count > 0) 
            {
                Coords here = visitList.GetPlace();
                if (_map[here.X, here.Y] == TileType.Noted)
                    _map[here.X, here.Y] = TileType.Visited;

                //když najdeš cíl, skonči
                if (_map[here.X, here.Y] == TileType.Exit)
                    return;

                //jinak přidej na seznam všechny neprojité sousedy
                Coords[] neighbours = Neighbours(here);
                foreach (Coords neighbour in neighbours)
                {
                    visitList.AddPlace(neighbour); //přidej na seznam
                    if (_map[neighbour.X, neighbour.Y] == TileType.Corridor)
                        _map[neighbour.X, neighbour.Y] = TileType.Noted; //poznač si, že už o něm víš
                }

                Console.ReadKey(); //počkám na klávesu
                RenderMaze(); //pak vykreslím a udělám další krok
            }
        }

        private Coords[] Neighbours(Coords location)
        {
            //co můžou být sousedi
            Coords[] possible =
            {
                new Coords(location.X, location.Y + 1),    
                new Coords(location.X, location.Y - 1),
                new Coords(location.X - 1, location.Y),
                new Coords(location.X + 1, location.Y),
            };
            
            List<Coords> result = new();
            
            //ověřím, že je má cenu přidat
            foreach (Coords where in possible)
            {
                if (where.X >= 0 && where.Y >= 0 && where.X < Width && where.Y < Height)
                {
                    //co tam je?
                    TileType what = _map[where.X, where.Y];

                    //když to chci, přidám
                    if (what == TileType.Corridor || what == TileType.Exit)
                        result.Add(where);
                }
            }

            return result.ToArray();
        }

    }
}
