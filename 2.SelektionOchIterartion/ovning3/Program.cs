using System;

namespace ovning3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1) { 
            Console.Write("Skriv tal 1: ");
            string tal1 = Console.ReadLine();
            Console.Write("Skriv tal 2: ");
            string tal2 = Console.ReadLine();

            decimal dec1 = decimal.Parse(tal1);

            decimal dec2 = decimal.Parse(tal2);

            if (dec1 < dec2)
            {
                    Console.WriteLine("Tal2 är störst");
            }
            else if (dec2 < dec1)
            {
                    Console.WriteLine("Tal1 är störst");
            }
            else if (dec1 == dec2)
                {
                    Console.WriteLine("Dom är lika!");
                }

                Console.WriteLine("-----------------------------------------------------------");


            }


        }
    }
}
