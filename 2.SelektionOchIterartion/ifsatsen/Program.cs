using System;
using System.Drawing;

namespace ifsatsen
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {
                Console.WriteLine("Hejdå World!");
                Console.WriteLine("Skriv in hur mycket sallad du har i din sallad i procent:");
                string inmat = Console.ReadLine();
                // int color = 100;
                int StoSRation = int.Parse(inmat);
                if (StoSRation < 50)
                {
                    Console.WriteLine("Respekt");

                }
                else if (StoSRation > 50)
                {
                    Console.WriteLine("Släng skiten");
                }
                else
                {
                    Console.WriteLine("du tog sönder programmet");
                }
               
                // Console.ForegroundColor = Color.FromArgb(color, color, color);


            }
        }
    }
}
