using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ligger på hemmadatorn

            Console.Write("Skriv in ditt nuvarande saldo <kr>: ");
            float saldo = float.Parse(Console.ReadLine());

            Console.Write("Skriv in räntan <%>: ");
            float ranta = float.Parse(Console.ReadLine());

            Console.Write("Skriv in sparmålet <kr>; ");
            float mal = float.Parse(Console.ReadLine());

            float ranta2 = (ranta / 100);
            Console.WriteLine("\n" + ranta);
            Console.WriteLine(ranta2);

            // det funkade inte att ha bara ranta2 som doulbe/decmal/flaot. Men med alla funkade varför????????????????????????????

           // float ar = 0;

           // mal = saldo * ranta2 ^ ar;
         //   sqrt 


          //  int mal = saldo * ranta2 ^ ar;


            // f(x)=c*a^2
            // mål = saldo * ränta^x
            Console.ReadLine();





        }
    }
}
