using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Board
    {
        const char CIRCLE = '\u25cf';   //원 코드?
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }
        public int destX { get; private set; }
        public int destY { get; private set; }


        Player _player;

        public enum TileType
        {
            Empty, Wall,
        }

        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;
            _player = player;

            destX = size - 2;
            destY = size - 2;

            //Binary Tree Algorithm
            Tile = new TileType[size, size];
            Size = size;


            //GenerateByBinaryTree();
            GenerateBySideWinder();

        }
        void GenerateBySideWinder()
        {
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }

            Random rand = new Random();


            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        Tile[y + 1, x - randomindex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }
    
        public void Render()
        {
            ConsoleColor preColor = Console.ForegroundColor;


            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                     if( y==_player.PosY && x == _player.PosX)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                     else if(destX == x && destY == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    }
                     
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }

        void GenerateByBinaryTree()
        {
            //길을 다 막아버리는 작업
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Tile[y, x] = TileType.Wall;
                    }
                    else
                    {
                        Tile[y, x] = TileType.Empty;
                    }
                }
            //랜덤으로 길 뚫는 작업
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        continue;
                    }

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
        }
    }
}

