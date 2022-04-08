using System;

namespace klassövning
{
    class Tärning
    {
        // Medlemsvariabel
        private int värde = 1;

        public Tärning(string värde)
        {

        }
        
        // Metoder
        public void Kasta()
        {
            Random rnd = new Random();

            värde = rnd.Next(1,6);
        }

        // Vi kan ksriva ut objekt som sträng. Console.Write(Tärning)
        public override string ToString()
        {
            return värde.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tärning tärning1 = new Tärning("aoif");

            Console.WriteLine(tärning1);

            tärning1.Kasta();

            Console.WriteLine(tärning1);

        }
    }
}
