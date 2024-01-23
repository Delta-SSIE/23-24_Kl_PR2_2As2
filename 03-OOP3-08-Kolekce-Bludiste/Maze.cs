using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Kolekce_02_Bludiste
{
    enum TileType { Wall, Corridor, Visited, Entrance, Exit }

    internal class Maze
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private Coords _entrance;
        private TileType[,] _map;
        private MazeDisplay _display;

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
                            'X' => TileType.Wall,
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
        }

        public void SolveMaze(IVisitList visitList)
        {
            visitList.AddPlace(_entrance); //napíšu si na seznam, že začínám na startu
            
            while (visitList.Count > 0) //dokud je, co vyzkoušet
            {
                Coords location = visitList.GetNextPlace(); //vyndám první místo na seznamu
                TileType locationTileType = _map[location.X, location.Y];

                if (locationTileType == TileType.Corridor || locationTileType == TileType.Entrance) //je tu chodba
                {
                    _map[location.X, location.Y] = TileType.Visited; //označím si ji
                    _display.RenderTile(location, TileType.Visited); //vykreslím jako projitou

                    Coords[] neighbours = Neighbours(location); //najdu sousedy svého místa
                    foreach (Coords neighbour in neighbours)
                    {
                        visitList.AddPlace(neighbour);
                    }
                }
                else if (locationTileType == TileType.Exit) //konec, jsem v cíli
                    break;

                
                Console.ReadKey(true);
            }

            _display.PlaceCursorBelow();
        }
        private Coords[] Neighbours(Coords coords) //všichni navštívitelní sousedé
        {
            Coords[] rawNeighbours = //všichni možní sousedé
            {
                new Coords(coords.X    , coords.Y - 1),
                new Coords(coords.X    , coords.Y + 1),
                new Coords(coords.X - 1, coords.Y),
                new Coords(coords.X + 1, coords.Y),
            };

            List<Coords> neighbours = new List<Coords>(); //sem dám ty, kteří jsou OK
            foreach (Coords neighbour in rawNeighbours) //projdu všechny surové
            {
                if (CanVisit(neighbour)) //když to jde, přidám na seznam
                { 
                    neighbours.Add(neighbour);
                }
            }

            return neighbours.ToArray();
        }
        
        private bool CanVisit(Coords coords) //říká, jestli se na pole dá vstoupit
        {
            if (coords.X < 0 || coords.X >= Width || coords.Y < 0 || coords.Y >= Height)
                return false; //mimo hranice pole

            return _map[coords.X, coords.Y] == TileType.Corridor || _map[coords.X, coords.Y] == TileType.Exit; //když je tam nenavštívená chodba nebo východ, vracím true, jinak false
        }
    }
}
