using System;

namespace WhileSatsenÖvning2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write password to initialize hacking: ");
            string pass = "null";
            string passright = "password";
            int timesFailed = 0;

            while (pass != passright)
            {
                
                pass = Console.ReadLine();
                timesFailed++;
                if (pass != passright)
                {
                    Console.WriteLine("You have succesfully showed your incompitence " + timesFailed + " times.");

                }

                if (timesFailed == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You bad hacker");
                    Console.WriteLine("Hacking failed to initilize");
                    break;
                    
                }

            }

            if (pass == passright)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Hacking initialized");
            }
        }
    }
}
