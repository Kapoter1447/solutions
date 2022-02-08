using System;

namespace NewFältÖv5_2DFält
{
    class Program
    {
        static void Main(string[] args)
        {
            int xSize = int.Parse(Console.ReadLine());
            int ySize = int.Parse(Console.ReadLine());
            int[,] board = new int[xSize, ySize];

            int x;
            int y;

            Random rnd = new Random();

            int rndX = rnd.Next(0, xSize);
            int rndY = rnd.Next(0, ySize);

            board[rndX,rndY] = 3;


            // First print (without guess)
            Console.WriteLine("\n");
            // X
            Console.Write("¤");
            for (int i = 0; i < xSize; i++)
            {
                Console.Write("|" + i);
            }
            Console.WriteLine("|");

            // Y
            for (int i = 0; i < ySize; i++)
            {
                Console.Write(i + "|");
                Console.WriteLine();
            }
            Console.WriteLine("\n ------------------ \n");



            // Guessing and printing
            while (true)
            {
                // Guess
                Console.Write("X: ");
                x = int.Parse(Console.ReadLine());

                Console.Write("Y: ");
                y = int.Parse(Console.ReadLine());


                
                // Ogissade = 0
                // Gissade fel = 1
                // Gissade rätt = 2
                // Ställen som är rätt = 3

                //kolla ifall rätt såfall gör en sak. om fel gör en annan
                if (!(board[x,y] == 3))
                {
                    board[x, y] = 1;
                }

                    Console.WriteLine("\n");
                    // X
                    Console.Write("¤");
                    for (int i = 0; i < xSize; i++)
                    {
                        Console.Write("|" + i);
                    }
                    Console.WriteLine("|");

                    // Y
                    for (int i = 0; i < ySize; i++)
                    {
                        Console.Write(i + "|");

                        for (int i2 = 0; i2 < xSize; i2++)
                        {
                            if (board[i2,i] == board[x,y] && board[x, y] == 3)
                            {
                                Console.Write("X ");
                            }
                            else if (board[i2, i] == 1)
                            {
                                Console.Write("¤ ");
                            }
                            else
                            {
                                Console.Write(". ");
                            }
                        }
                        Console.WriteLine();

                    }
                    Console.WriteLine("\n ------------------ \n");




            }

        }
    }
}
