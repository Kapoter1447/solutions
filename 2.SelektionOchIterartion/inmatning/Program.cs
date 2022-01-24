using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inmatning
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.Write("Start: ");
                int start = int.Parse(Console.ReadLine());

                Console.Write("Stop: ");
                int stop = int.Parse(Console.ReadLine());

                Console.Write("Steg: ");
                int steg = int.Parse(Console.ReadLine());

                for (int i = start; i <= stop; i = i + steg)
                {
                    Console.WriteLine(i);
                }

                Console.ReadLine();
            }
        }
    }
}
