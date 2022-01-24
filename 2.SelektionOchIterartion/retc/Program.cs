using System;


namespace retc
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            Random rnd4 = new Random();

            Console.WriteLine("Click To initialize hacking");
            Console.ReadLine();

            for (int times = 0; times < 15; times++)
            {

                int random1 = rnd.Next(0, (int)100);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Searching " + random1 + " networks");
                Console.ForegroundColor = ConsoleColor.Red;

                int random2 = rnd2.Next(0, 5000);
                int random3 = rnd3.Next(0, 6);


                if (random1%2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (random1 > 150)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Warning: Low connection rate");
                         Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (random1 < 50)
                    {
                        Console.WriteLine("Kachow connection broder");
                    }

                    for (int i = 0; i < random1/2; i++)
                    {
                        Console.WriteLine("Searching Mainframe " + random1 + i);
                        System.Threading.Thread.Sleep(random1);

                    }



                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine("Global Mainframe with " + random2 + " computers found");
                    Console.WriteLine("Connecting to network");
                    Console.WriteLine("...");
                    System.Threading.Thread.Sleep(1000);


                    //Randomiserar antal datorer som blir hackade
                    for (int i2 = 0; i2 < random3; i2++)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Hacking computer with ID " + i2 + (random1/2));


                        //Randomiserar antal punkter
                        int random4 = rnd4.Next(2, 10);
                        for (int i = 0; i < random4; i++)
                        {
                                Console.Write(".");
                                System.Threading.Thread.Sleep(500);

                         }
                         Console.ForegroundColor = ConsoleColor.Blue;
                         Console.WriteLine();
                         Console.WriteLine("Computer Hacked");
                         Console.ForegroundColor = ConsoleColor.Red;



                    }

                    Console.WriteLine();
                }




            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("World domination reached");
            Console.WriteLine("You can now close this window");
            Console.ReadLine();

        }
    }
}
