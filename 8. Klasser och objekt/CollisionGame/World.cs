using System;
using System.Collections.Generic;
using System.Text;

namespace CollisionGame
{
    class World
    {
        private int xSize;
        private int ySize;


        //Medlemsvariabler
        string[,] world;

        //Konstruktor
        public World(int xLength, int yLength)
        {
            world =  new string[xLength, yLength];

            xSize = xLength;
            ySize = yLength;
        }

        //Metoder
        public override string ToString()
        {
            return base.ToString();
        }

        public int x
        {
            get
            {
                return xSize;
            }
        }
        public int y
        {
            get
            {
                return ySize;
            }
        }


        public void PlaceText(string item, int x, int y, string direction)
        {
            // World length -1 för att annars hamnar den utanför
            int xClamp = Math.Clamp(x, 0, world.GetLength(0) - 1);
            int yClamp = Math.Clamp(y, 0, world.GetLength(1) - 1);
            if (direction == "horizontal")
            {
                for (int i = 0; i < item.Length; i++)
                {
                    xClamp = Math.Clamp(xClamp + 1, 0, world.GetLength(0) - 1);

                    world[xClamp, yClamp] = item[i].ToString();
                }
            }
            else if (direction == "vertical")
            {
                for (int i = 0; i < item.Length; i++)
                {
                    yClamp = Math.Clamp(yClamp + 1, 0, world.GetLength(1) - 1);

                    world[xClamp, yClamp] = item[i].ToString();
                }
            }
            else
            {
                Console.WriteLine("Fel 'direction' i text: " + item);
            }
        }

        public void Place(string[] itemArray, int x, int y)
        {
            int xClamp = Math.Clamp(x, 0, world.GetLength(0) - 1);
            int yClamp = Math.Clamp(y, 0, world.GetLength(1) - 1);

            for (int i = 0; i < itemArray.Length; i++)
            {
                yClamp = Math.Clamp(yClamp + 1, 0, world.GetLength(1) - 1);

                world[xClamp, yClamp] = itemArray[i];
            }
        }

        public void Place(string item, int x, int y)
        {
            int xClamp = Math.Clamp(x, 0, world.GetLength(0) - 1);
            int yClamp = Math.Clamp(y, 0, world.GetLength(1) - 1);

            int xBefore = xClamp;

            while (world[xClamp, yClamp] != null) // Ifall plats i array är upptagen, flytta föremål tillfälligt till höger.
            {
                xBefore = xClamp;
                xClamp++;
                xClamp = Math.Clamp(xClamp, 0, world.GetLength(0) - 1); // Clampar igen för att undvika att värdet hamnar utanför array
                
                if (xClamp == xBefore) // Ifall x värdet är samma som förut har denna nått en kant och skrivs därför över
                {
                    break;
                }
            }

            world[xClamp, yClamp] = item;
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

                    // Ifall tecken är tomt så ska det inte bli massa mellanrum där som täcker annat
                    if (itemArray[b, a] != "")
                    {
                        world[xClamp, yClamp] = itemArray[b, a];
                    }
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
                           // Console.WriteLine(xSearch + "," + ySearch);
                            for (int b = 0; b < 3; b++)
                            {
                                // Clampar sökkordinaterna så att de inte hamnar utanför världskoordinaterna
                                int xClamp = Math.Clamp(x + xSearch, 0, world.GetLength(0) - 1);
                                int yClamp = Math.Clamp(y + ySearch, 0, world.GetLength(1) - 1);

                                if (world[xClamp, yClamp] == object2)
                                {
                                    collision = true;
                                }
                                xSearch++;
                            }
                            ySearch++;
                        }
                    }
                }
            }

            return collision;

        }
        
        public bool CheckCollision(string object1, string object2, string direction)
        {
            // direction "up" would give modifier a(y) = -1 och b(x) = 0.
            // (-1,-1)(0,-1)(1,-1)
            // (-1,0) Object (1,0)   Object is placetd at (0,0)
            // (-1,1) (0,1) (1,1)

            bool collision = false;

            int xSearch = 0;
            int ySearch = 0;

            switch (direction)
            {
                case "up":
                    xSearch = 0;
                    ySearch = -1;
                    break;

                case "down":
                    xSearch = 0;
                    ySearch = 1;
                    break;

                case "left":
                    xSearch = -1;
                    ySearch = 0;
                    break;

                case "right":
                    xSearch = 1;
                    ySearch = 0;
                    break;

                default:
                    break;
            }

            // Söker igenom 'world' array
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    // Ifall hittar 'object1'. Utgår från ett lokalt koordinatsystem 3X3 runt...
                    // ...kollisionsobjekt som utgår från x och y koordinat av objekt.
                    // Tar först både x och y värde -1 vilket gör att övre vämntra hörnet kommer kollas.
                    if (world[x, y] == object1)
                    {
                        // Clampar sökkordinaterna så att de inte hamnar utanför världskoordinaterna
                        int xClamp = Math.Clamp(x + xSearch, 0, world.GetLength(0) - 1);
                        int yClamp = Math.Clamp(y + ySearch, 0, world.GetLength(1) - 1);

                        if (world[xClamp, yClamp] == object2)
                        {
                            collision = true;
                        }
                    }
                }
            }

            return collision;

        }

        public void Print()
        {
            string render = "";

            Console.SetCursorPosition(0, 0);
            // För att optimisera lägg till allt i chararray och sen skriv ut. 
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    // Ifall tom skriv ut mellanrum annars skriv ut vad som finns på den platsen
                    if (world[x,y] == null)
                    {
                        render = render + " ";
                       // Console.Write(" ");
                    }
                    else
                    {
                        render = render + world[x, y];
                        //Console.Write(aworld[x,y]);
                    }
                }
                render = render + "\n";
                // Console.WriteLine();
            }
            Console.WriteLine(render);
            render = "";

            // Clears array
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = null;
                }
            }
        }
        
        public void Clear()
        {
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
