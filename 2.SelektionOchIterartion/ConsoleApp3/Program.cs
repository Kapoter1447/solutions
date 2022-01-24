using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 == 1)
            {

                Random rnd = new Random();

                int randomNumber = rnd.Next(1, 100);

                Console.WriteLine("Gissa tal blablabla mellan 1 och 100 ");

                int guessed = 0;
                int antalGissade = 0;


                while (guessed != randomNumber)
                {
                    Console.WriteLine("haha nej");
                    guessed = int.Parse(Console.ReadLine());
                    antalGissade++;


                    if (guessed < randomNumber)
                    {
                        Console.WriteLine("för lite broder");
                    }
                    else if (guessed > randomNumber)
                    {
                        Console.WriteLine("för mycket jaoouuu");
                    }




                }

                Console.WriteLine("nice du klarade det");
                Console.WriteLine("Så här mpånga gåneger gissade du och såg fett dum ut " + antalGissade + "\n" + "\n"  + "---------------------------------");

            }

        }
    }
}
