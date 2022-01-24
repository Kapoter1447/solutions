using System;

namespace WhileSatsenÖvning1
{
    class Program
    {
        static void Main(string[] args)
        {
        //    bool bool1 = true;
            int tal1 = 0;

            while (tal1 < 100)
            {

                tal1 += 1;
                Console.WriteLine(tal1);
                System.Threading.Thread.Sleep(50);
                
            }
        }
    }
}
