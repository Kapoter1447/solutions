using System;

namespace FältÖv5TvådimensionellaFält
{
    class Program
    {
        static void Main(string[] args)
        {
            int xSize = int.Parse(Console.ReadLine());
            int ySize = int.Parse(Console.ReadLine());

            Console.WriteLine("\n");

            int[,] board = new int[xSize + 1, ySize + 1];

            printBoard();

            Console.ReadLine();







            void printBoard()
            {
                // X
                Console.Write("¤");
                for (int i = 0; i < xSize; i++)
                {
                    Console.Write("|" + (i + 1));
                }
                Console.WriteLine("|");

                // Y
                for (int i = 0; i < ySize; i++)
                {
                    Console.WriteLine((i + 1) + "|");
                }

                Console.WriteLine("\n ------------------ \n");

            }


        }
    }
}
