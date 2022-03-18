using System;
using System.Collections.Generic;
using System.Threading;


namespace Roleplay_2019_version
{
    class Program
    {
        static void Main(string[] args)
        {
            string inmat = "";
            

            #region Stickman
           
            #endregion

            while (inmat != "3")
            {
                Console.Clear();
                MenyPrint("Spela äventyret \"Bob är kidnappad\"", "Tärnings simulator", "Regler och Teori", "Avsluta");
                inmat = Console.ReadLine();

                switch (inmat)
                {
                    case "1":
                        // Metod för äventyr
                        break;

                    case "2":
                        Console.WriteLine("sim");
                        TärningSimulator();
                        break;

                    case "3":
                        // Metod för regler
                        break;

                    case "4":
                        WriteRed("Lämnar ett episkt äventy...");
                        Thread.Sleep(1000);
                        break;

                    default:
                        WriteRed("Fel vid inmat. Försök igen.");
                        Console.Clear();
                        break;
                }
            }
        }

        static void Streckgubbe()
        {
            int delay = 100;

            Console.WriteLine("   ==");
            Thread.Sleep(delay);
            Console.WriteLine("  ====");
            Thread.Sleep(delay);
            Console.WriteLine(" ======");
            Thread.Sleep(delay);
            Console.WriteLine(" ----- ");
            Thread.Sleep(delay);
            Console.WriteLine("|  .. |");
            Thread.Sleep(delay);
            Console.WriteLine("|  -  |");
            Thread.Sleep(delay);
            Console.WriteLine(" _____ ");
            Thread.Sleep(delay);
            Console.WriteLine("  |||  ");
            Thread.Sleep(delay);
            Console.WriteLine(" ||||| ");
            Thread.Sleep(delay);
            Console.WriteLine("¤--|--#-->==========>   ");
            Thread.Sleep(delay);
            Console.WriteLine(" ||||| ");
            Thread.Sleep(delay);
            Console.WriteLine(" |||||");
            Thread.Sleep(delay);
            Console.WriteLine("   |   ");
            Thread.Sleep(delay);
            Console.WriteLine(" -- --  ");
            Thread.Sleep(delay);
            Console.WriteLine(" |    | ");
            Thread.Sleep(delay);
            Console.WriteLine(" |    | ");
            Thread.Sleep(delay);
            Console.WriteLine("=|    |=");
            Console.WriteLine("             ||----------------------------\\");
            Console.WriteLine("=============||===============================|");
            Console.WriteLine("             ||----------------------------/");
            Console.WriteLine("DOD SIMULATOR!!!!");
            Thread.Sleep(2000);
            Console.Clear();
        }

        static void TärningSimulator()
        {
            Console.WriteLine("Början tpå sim");
            string inmat = "";

            while (inmat != "5")
            {
                Console.Clear();
                MenyPrint("1t00","1t10" ,"1t20" ,"1t6" , "Avsluta");
                Console.Write("Kasta tärning: \"");
                WriteBlue("x");
                Console.Write("t");
                WriteBlue("y");
                Console.WriteLine("\" där x är antalet tärningar och y är hur många sidor tärningen har. Eller välj en av förinställningarna ovan.");

                inmat = Console.ReadLine();

                switch (inmat)
                {
                    case "1":
                        WriteGreen("|::|  = " + KastaTärning("1t100").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "2":
                        WriteGreen("|::|  = " + KastaTärning("1t10").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "3":
                        WriteGreen("|::|  = " + KastaTärning("1t20").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "4":
                        WriteGreen("|::|  = " + KastaTärning("1t6").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "5":
                        WriteRed("Lämnar en episk tärningssimulator");
                        break;

                    default:
                        WriteGreen("|::|  = " + KastaTärning(inmat).ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("slut på sim");
            }
        }

        static void MenyPrint(string val1, string val2, string val3, string val4, string val5)
        {
            List<string> menyVal = new List<string>()
            {
                {val1},
                {val2},
                {val3},
                {val4},
                {val5}
            };
            int i = 1;

            Console.WriteLine("--->============>");
            foreach (var val in menyVal)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val);
                i++;
                Thread.Sleep(200);
            }
            Console.WriteLine("--->============>");

        }

        static void MenyPrint(string val1, string val2, string val3, string val4)
        {
            List<string> menyVal = new List<string>()
            {
                {val1},
                {val2},
                {val3},
                {val4},
            };
            int i = 1;

            Console.WriteLine("--->============>");
            foreach (var val in menyVal)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val);
                i++;
                Thread.Sleep(200);
            }
            Console.WriteLine("--->============>");

        }

        static void MenyPrint(string val1, string val2, string val3)
        {
            List<string> menyVal = new List<string>()
            {
                {val1},
                {val2},
                {val3},
            };
            int i = 1;

            Console.WriteLine("--->============>");
            foreach (var val in menyVal)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val);
                i++;
                Thread.Sleep(200);
            }
            Console.WriteLine("--->============>");
        }

        static void MenyPrint(string val1, string val2)
        {
            List<string> menyVal = new List<string>()
            {
                {val1},
                {val2},
            };
            int i = 1;

            Console.WriteLine("--->============>");
            foreach (var val in menyVal)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val);
                i++;
                Thread.Sleep(200);
            }
            Console.WriteLine("--->============>");
        }

        static void MenyPrint(string val1)
        {
            List<string> menyVal = new List<string>()
            {
                {val1},

            };
            int i = 1;

            Console.WriteLine("--->============>");
            foreach (var val in menyVal)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val);
                i++;
                Thread.Sleep(200);
            }
            Console.WriteLine("--->============>");
        }

        static int KastaTärning(string tärningsData)
        {
            string[] dataSplit = tärningsData.Split('t');
            Random random = new Random();
            int värde = 0;

            for (int i = 0; i < int.Parse(dataSplit[0]); i++)
            {
                värde = värde + random.Next(0, int.Parse(dataSplit[1]));
            }

            return värde;
        }

        #region färger
        static void WriteRed(string textRöd)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(textRöd);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void WriteGreen(string textGreen)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(textGreen);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void WriteBlue(string textBlue)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(textBlue);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion


    }
}
