using System;

namespace IFSatsenÖvning2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1) { 

            Console.WriteLine("SKriv din ålder för att få en färg som korresponderar med åldern på en bricka:");
            int alder = int.Parse(Console.ReadLine());

            if (alder <= 12 && alder > 0)
            {
                Console.WriteLine("Under 12: vit");
            }
            else if (alder > 12 && alder <= 18)
            {
                Console.WriteLine("Mellan 13-18: grön");
            }
            else if (alder > 18 && alder <= 25)
            {
                Console.WriteLine("Mellan 19-25: röd");
            }
            else if (alder > 25 && alder <= 99)
            {
                Console.WriteLine("Mellan 26-99: blå");
            }
                else
                {
                    Console.WriteLine("Ogiltig ålder");
                }



            }

        }
    }
    }

