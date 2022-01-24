using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heltaladdition
{
    class Program
    {
        static void Main(string[] args)
        {

            while (1 == 1)
            {
                
            Console.Write("Mata in heltal: ");
            int heltal = int.Parse(Console.ReadLine());
            int counting = 0;

            for (int i = 0; i < heltal; i++)
            {
                Console.WriteLine("Föregående tal: " + counting + " + nuvarande heltal: " + (i+1) + " = " + (counting += i + 1));

            }


            Console.WriteLine("Summan av alla tal från 1 till " + heltal + " blir: " + counting);
                Console.WriteLine("--------------------------------------------------");


            }
        }
    }
}
