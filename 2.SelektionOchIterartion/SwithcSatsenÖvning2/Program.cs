using System;

namespace SwithcSatsenÖvning2
{
    class Program
    {
        static void Main(string[] args)
        {
            // INTE KLAR! Osäker på om swithc satsen fungerar på strings på något sätt elelr m jag ska konvertera bokstäver till nummer. 
            // https://csharpskolan.se/article/switch-satsen/ 

            Console.WriteLine("Välkommen till ett fantastiskt textäventyr. Skriv in första bokstaven i ett värdetreck för att gå åt det hållet:");
            string direction = Console.ReadLine();

            switch(direction)
            {
                case "N":
                    Console.WriteLine();
                    break;

                case "S":
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    break;

            }
        }
    }
}
