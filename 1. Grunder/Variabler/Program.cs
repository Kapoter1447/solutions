using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variabler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Skriv ditt bra tal:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string tal1;
            tal1 = Console.ReadLine();
            Console.WriteLine("du skrev: " + tal1);
                    
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("skriv tal 2");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            string tal2;
            tal2 = Console.ReadLine();
            Console.WriteLine("Du skrev: " + tal2);

            int parse2 = int.Parse(tal1);
            int parse1  = int.Parse(tal2);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Plus (matematisk rebell): " + (parse1+parse2));
            Console.WriteLine("Subtraktor: " + (parse1 - parse2));
            Console.WriteLine("Dividierasion: " + (parse1 / parse2));
            Console.WriteLine("gånger: " + (parse2*parse1));


            Console.ReadLine();


        }
    }
}
