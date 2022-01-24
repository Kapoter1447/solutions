using System;

namespace delbart3och7
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1==1)
            {
                Console.Write("Mata in ett heltal: ");
                int var1 = int.Parse(Console.ReadLine());
                int var2 = 0;

                for (int i = 0; i < var1; i++)
                {
                    var2 += i + 1;

                    if (var2 % 7 == 0 && var2 % 3 == 0)
                    {
                        Console.Write("Talet ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(var2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" kan delas med både 3 och 7 ");
                   
      
                    }
                    else if (var2 % 7 == 0)
                    {
                        Console.Write("Talet ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(var2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" kan delas med 7 ");

                    }
                    else if (var2 % 3 == 0 )
                    {
                        Console.Write("Talet ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(var2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" kan delas med 3 ");
                    }
                    else
                    {
                        Console.WriteLine("Talet " + var2 + " suger");
                    }

     

                }
                Console.WriteLine();

            }
        }
    }
}
