using System;

namespace WhileSatsenÖvning8
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Year: " + DateTime.Now.Year);

            int year = DateTime.Now.Year;



            while (!(year == 2051))
            {
                bool leap = DateTime.IsLeapYear(year);
          //      Console.WriteLine(leap);

                if (leap == true)
                {
                    Console.WriteLine(year + " is a leapyear.");
                    year++;
                }
                else
                {
                    year++;
                }

         //       Console.WriteLine("Ett varv kört");

            }


            Console.WriteLine("Process klar");

        }
    }
}
