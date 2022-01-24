using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            while(1==1)
            { 
            Console.WriteLine("Hello World!");
            string inmat = Console.ReadLine();

            int tal = int.Parse(inmat);

            if (tal % 7 == 0)
            {
                Console.WriteLine("Delbart med 7");

            }
            else
            {
                Console.WriteLine("neh inte delbart med 7");
            }

            }

        }
    }
}
