using System;

namespace FältÖv1AllaNamn1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] namn = new string[5];

            for (int i = 0; i < namn.Length; i++)
            {
                namn[i] = Console.ReadLine();
            }
            Console.WriteLine("\n");
            for (int i = 0; i < namn.Length; i++)
            {
                Console.WriteLine(i + ": " + namn[i]);
            }
           
            string inmat = "";
            int intmat = 0;

            bool isInt = false;



            while (isInt = false)
            {
                if (!int.TryParse(inmat, out intmat))
                {
                    Console.WriteLine("Quit");
                    isInt = true;
                }
                else
                {
                    intmat = int.Parse(Console.ReadLine());
                    Console.WriteLine(namn[intmat]);
                }
            }
        }
    }
}
