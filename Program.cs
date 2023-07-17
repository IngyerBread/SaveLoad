using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static int[,] map;

        static int[,] map1 =
        {
            {1,1,1,1,1,1,1,1,1,1,1,9,1,1,1 },
            {1,0,1,0,2,0,4,0,0,0,1,0,0,0,1 },
            {1,0,1,0,1,0,0,0,4,0,1,1,1,0,1 },
            {1,0,1,0,1,0,4,0,4,0,1,0,4,0,1 },
            {1,0,1,0,1,0,0,0,4,0,1,0,4,0,1 },
            {1,0,1,0,1,0,4,4,4,0,4,0,0,0,1 },
            {1,0,0,0,1,0,0,0,0,4,2,0,1,0,1 },
            {1,0,1,0,1,4,4,4,0,4,0,4,4,4,1 },
            {1,3,1,3,1,0,0,0,0,0,0,2,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };

        static int[,] map2 =
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };

        static bool StageClear = true;
        static void MapLoad()
        {
            if(StageClear == true && !(map == map1))
            {
                StageClear = false;
                map = map1;
            }

            else if (StageClear == true && map == map1)
            {
                StageClear = false;
                map = map2;
                playerX = 1;
                playerY = 1;
            }

            else if(StageClear == false)
            {

            }

            else
            {
                gameOver = true;
            }


        }

        static int playerX = 1;
        static int playerY = 1;

        static bool gameOver = false;
        static bool hasKey = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Press Any Key to Start");
            while(!gameOver)
            {
                MapLoad();
                ConsoleKeyInfo ipKey = Console.ReadKey();
                KeyControl(ipKey);
                Console.Clear();
                Render();
                Console.WriteLine(MassegeToUser);
            }

            if(gameOver)
            {
                Console.WriteLine("GameOver!");
            }
            
        }

        static string MassegeToUser = " ";

        static void MassegeChange(string ipMassege)
        {
            MassegeToUser = ipMassege;
        }

        static int[] Render()
        {
            // 0 평지 1벽 2잠긴문 3열쇠 4지뢰
            int x = 0;
            int y = 0;

            for(y = 0; y < map.GetLength(0); ++y)
            {
                for (x = 0; x < map.GetLength(1); ++x)
                {
                    if (playerX == x && playerY == y)
                    {
                        Console.Write("P" + " ");
                    }

                    else if (map[y, x] == 0)
                    {
                        Console.Write(" " + " ");
                    }

                    else if (map[y, x] == 1)
                    {
                        Console.Write("*" + " ");
                    }

                    else if (map[y,x] == 2)
                    {
                        Console.Write("X" + " ");
                    }

                    else if (map[y, x] == 3)
                    {
                        Console.Write("k" + " ");
                    }

                    else if (map[y, x] == 4)
                    {
                        Console.Write("o" + " ");
                    }

                    else if (map[y, x] == 5)
                    {
                        Console.Write("A" + " ");
                    }

                    else if (map[y, x] == 9)
                    {
                        Console.Write("$" + " ");
                    }
                }

                Console.WriteLine(" ");

            }
            int[] res = new int[2];
            res[0] = y;
            res[1] = x;
            return res; 
        }

        static void KeyControl(ConsoleKeyInfo key)
        {
            int targetX = playerX;
            int targetY = playerY;

            switch(key.Key)
            {
                case ConsoleKey.W:
                    targetY--;
                    break;
                case ConsoleKey.S:
                    targetY++;
                    break;
                case ConsoleKey.A:
                    targetX--;
                    break;
                case ConsoleKey.D:
                    targetX++;
                    break;
            }

            MapControl(targetX, targetY);
            

        }

        static void MapControl(int targetX, int targetY)
        {
            

            if (map[targetY,targetX] == 2 && hasKey == false)
            {
                MassegeChange("Need Key to Enter Door");
            }

            else if (map[targetY, targetX] == 2 && hasKey == true)
            {
                map[targetY, targetX] = 0;
                hasKey = false;
            }

            else if (map[targetY, targetX] != 1)
            {
                playerX = targetX;
                playerY = targetY;
                MassegeChange(" ");
            }



            if (map[targetY, targetX] == 3 && hasKey == false)
            {
                map[targetY, targetX] = 0;
                hasKey = true;
            }

            if (map[targetY, targetX] == 4)
            {
                gameOver = true;
            }

            if (map[targetY, targetX] == 9)
            {
                StageClear = true;
            }


        }

        static void EnemyControl()
        {
            while(true)
            {

            }
        }

    }



}
