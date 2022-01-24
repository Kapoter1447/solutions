using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv celsius");
            string celsius;
            celsius = Console.ReadLine();
            int celsiusInt = int.Parse(celsius);

            Console.Write(celsius + "*C är samma sak som " + (1.8 * celsiusInt + 32) + "*F");
            Console.ReadLine();

        }
    }
}
