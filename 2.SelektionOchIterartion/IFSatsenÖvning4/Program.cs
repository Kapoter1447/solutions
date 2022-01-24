using System;

namespace IFSatsenÖvning4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1) { 
            Console.WriteLine("Skriv in ett heltal för att kolla om det är delbart med 7");
            int inmat = int.Parse(Console.ReadLine());

            if (inmat % 7 == 0)
            {
                Console.WriteLine("Talet är delbart med 7");
                    Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Talet är inte delbart med 7");
                    Console.WriteLine("Resten är " + (inmat%7));
                    Console.WriteLine();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();
            }

            }
        }
    }
}
