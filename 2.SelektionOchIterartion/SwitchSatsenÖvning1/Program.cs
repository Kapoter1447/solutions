using System;

namespace SwitchSatsenÖvning1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1) { 

            Console.WriteLine("Hejdå World!");
            Console.Write("skriv tal:");
            int inmat = int.Parse(Console.ReadLine());

            switch(inmat)
            {
                case 1:
                    Console.WriteLine("1");
                    break;

                case 2:
                    Console.WriteLine("2");
                    break;

                case 3:
                    Console.WriteLine("3");
                    break;

                case 4:
                case 5:
                    Console.WriteLine("4 eller 5");
                    break;

                default:
                    Console.WriteLine("nej");
                    break;

            }

                Console.WriteLine();
            }
        }
    }
}
