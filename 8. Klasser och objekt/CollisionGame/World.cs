using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class World
    {
        //Medlemsvariabler
        string[,] world;

        //Konstruktor
        public World(int xLength, int yLength)
        {
            world =  new string[xLength, yLength];
        }

        //Metoder
        public override string ToString()
        {
            return base.ToString();
        }

        public void Place(string item, int x, int y)
        {
            int xClamp = Math.Clamp(x, 0, world.GetLength(0)-1);
            int yClamp = Math.Clamp(y, 0, world.GetLength(1)-1);

            world[xClamp, yClamp] = item;
            // Gör så att man inte kan sätta utanför världen
        }

        public void Place(string[,] itemArray, int x, int y)
        {
            // Placerar ut varje x och y koordinat i 'itemarray' till världskoordinatsystemet.

            for (int a = 0; a < itemArray.GetLength(1); a++)
            {
                for (int b = 0; b < itemArray.GetLength(0); b++)
                {
                    // Clampar värdet så att programmet inte crashar när utanför world array.
                    int xClamp = Math.Clamp(x+a, 0, world.GetLength(0) - 1);
                    int yClamp = Math.Clamp(y+b, 0, world.GetLength(1) - 1);

                    world[xClamp,yClamp] = itemArray[b, a];
                }
            }
        }

        public bool CheckCollision(string object1, string object2)
        {
            bool collision = false;



            // Söker igenom 'world' array
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    // Ifall hittar 'object1'. Utgår från ett lokalt koordinatsystem 3X3 runt...
                    // ...kollisionsobjekt som utgår från x och y koordinat av objekt.
                    // Tar först både x och y värde -1 vilket gör att övre vämntra hörnet kommer kollas.
                    if (world[x,y] == object1)
                    {
                        int xSearch = -1;
                        int ySearch = -1;

                        for (int a = 0; a < 3; a++)
                        {
                            xSearch = -1;
                            Console.WriteLine(xSearch + "," + ySearch);
                            for (int b = 0; b < 3; b++)
                            {
                                // Clampar sökkordinaterna så att de inte hamnar utanför världskoordinaterna
                                int xClamp = Math.Clamp(x + xSearch, 0, world.GetLength(0) - 1);
                                int yClamp = Math.Clamp(y + ySearch, 0, world.GetLength(1) - 1);

                                if (world[xClamp, yClamp] == object2)
                                {
                                    Console.WriteLine("Collision!!");
                                    collision = true;
                                }
                                xSearch++;
                            }
                            ySearch++;
                        }
                    }
                }
            }

            if (collision)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Print()
        {
            Console.SetCursorPosition(0, 0);
            // För att optimisera lägg till allt i chararray och sen skriv ut. 
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    // Ifall tom skriv ut mellanrum annars skriv ut vad som finns på den platsen
                    if (world[x,y] == null)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(world[x,y]);
                    }
                }
                Console.WriteLine();
            }

            // Clears array
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = null;
                }
            }
        }

    }
}
