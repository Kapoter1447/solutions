using System;

namespace FältÖv3Väderstationen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("antal mätningar: ");

            int antalMätningar = int.Parse(Console.ReadLine());

            double[] temp = new double[antalMätningar];

            for(int i = 0; i < temp.Length; i++)
            {
                temp[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n");

            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine();
            }

        }
    }
}
