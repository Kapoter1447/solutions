using System;

namespace WhileSatsenÖvning5
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 0;
            int b = 1;
            int c = 0;
            Console.WriteLine(a);
            Console.WriteLine(b);
            while (c < 1000000)
            {
                c = a + b;
                Console.WriteLine(c);
                a = b;
                b = c;
             //   System.Threading.Thread.Sleep(500);
            }

            Console.WriteLine();
        }
    }
}
