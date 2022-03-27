using System;
using System.Collections.Generic;
using System.Threading;


// Vill skriva ut stats i coola listor
// Metod för att rita saker med writeAt eller setCursor
// List med vapen. Där varje index är ett vapen och sen gör något sätt att tolak listan på. Blir lätt att lägga till vapen.

namespace Roleplay_2019_version
{
    class Program
    {
        // Beteckningar: kp = liv, va = vapen, cl = chans att lyckas i %, da = damage, be = beskrivning.

        static Dictionary<string, string> stats = new Dictionary<string, string>() {

            {"spelare","kp10; vayxa; cl90;"},
            {"mattant","kp6; vamorotssoppa; cl70; vastor slev;"},
            {"rektorn","kp200; vaen helvetes penna; cl100;"}

        };

        static Dictionary<string, string> attacker = new Dictionary<string, string>()
        {
            {"rå styrka", "DA1t3; BEAttackerar med näven;"  },
            {"stor slev", "DA1t6; BEbeskrivning till stor slev;" },
            {"morotssoppa", "DA2t6; BEMattanten tar fram sin onda kittel och börjar brygga en stinkande orange vätska. Du ryggar av stanken av det giftigaste på jordens yta tillagas framför dig. Helt plötsligt tar mattanten en slev med morotsoppa och kastar mot dig!;" },
        };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                Console.WriteLine("Fiendeattack:");
                FiendeAttack("mattant");
                Console.WriteLine("Spelarattack:");
                SpelarAttack();
                Console.ReadLine();
            }


            Console.ReadLine();

            string inmat = "";

            #region Stickman
           
            #endregion

            while (inmat != "3")
            {
                Console.Clear();
                MenyPrint("Spela äventyret \"Mattanterna har kidnappat rektorn! fanciction\"", "Tärnings simulator", "Regler och Teori", "Avsluta");
                inmat = Console.ReadLine();

                switch (inmat)
                {
                    case "1":
                        Äventyr();
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

        static void Äventyr()
        {
            Console.Clear();

            Console.WriteLine("Å nej bla bla bla har hänt! Helvete! \nAAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaah en mattant");
            Slåss("mattant");
            // kasta hårda och torra falaflar. förgifta med morotsoppa.

            MenyPrint("Använd din döda farfarsfars stridsyxa", "Använd m9 beretta 9x19mm 380m/s akimbo pistol", "gitta away", "Checka stats");

            Console.ReadLine();

        }

        static void Slåss(string fiendeTyp)
        {
            Initiativ(fiendeTyp);

            // ta in fiende stats: skada på vapen, helningsförmåga, ev rustning, kp
            // ta in avstånd


            // Ifall fiende börjar:
            // Slumpa en attack
            // Kolla om den lyckas (cl)
            // ifall lyckas ta skada

            // extract vapen från spelardata med samma namn som fiendetyp elelr spelaren


            // vem som börjar bestäms av initatitv

            Random rnd = new Random();

            switch (rnd.Next(0,1))
            {
                case 0:
                    FiendeAttack(fiendeTyp);
                  break;

                case 1:
                    SpelarAttack();

                    break;

                default:
                    break;
            }

            // Plockar fram vapnen ur statslistan för aktuell fiende

        }


        static void FiendeAttack(string fiendetyp)
        {
            Console.Clear();

            #region slumpa attack
            // Letar upp alla attacker/vapen "fiendetyp" kan använda. Sedan blandas dessa och väljer en. Ifall inte returnerar något vapen, kör hand attack.
            string vapenPaket = SSID(fiendetyp, "va", ";", stats);
            string[] vapen = vapenPaket.Split('¤');
            string[] blandadeVapen = blanda(vapen);
            string aktivtVapen = blandadeVapen[0];
            #endregion

            // fan slumpmässigt om den hittar beskrivningen orkar inte
            WriteRed(fiendetyp.ToUpper() + " ATTACKERAR! \n");
            WriteGrey(SSID(aktivtVapen, "BE", ";", attacker) + "\n");

            int cl = int.Parse(SSID(fiendetyp, "cl", ";", stats));

            Console.Write("\n" + fiendetyp + " har ");
            WriteBlue(cl + "% ");
            Console.Write("att lyckas \n");

            MenyPrint("'Enter' för att slå tärning (1t100)");
            Console.ReadLine();
            TärningAnimation();

            int resultat = KastaTärning("1t100");
            WriteGreen(" = " + resultat);

            if (resultat < cl)
            {
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + resultat + " < " + cl );
                    Thread.Sleep(200);
                }
                WriteRed("\n" + fiendetyp + " lyckas med attacken.");
             //   Console.WriteLine("\n\nEnter för att fortsätta...");
                Console.ReadLine();
               // Console.Clear();

                // Kolla skada. Hitta spelar kp och ta kp - skada. Ta sedan bort nuvarnade kp substräng och sen skapa en ny med nya kp:t.
                int kp = int.Parse(SSID("spelare", "kp", ";", stats));
                string tärningSkada = SSID(aktivtVapen, "DA", ";", attacker);

                Console.Write("\nDu har ");
                WriteBlue(kp.ToString());
                Console.Write(" kp.\n");

                Console.Write(aktivtVapen + " gör ");
                WriteBlue(tärningSkada);
                Console.Write(" skada.\n");

                MenyPrint("'Enter' för att slå tärning fär skada");
                Console.ReadLine();
                TärningAnimation();
                
                int skada = KastaTärning(tärningSkada);
                int kpInnan = kp;
                kp = kp - skada;

                WriteRed(" = " + skada);
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + kpInnan + "kp - " + skada + "skada = " + kp + "kp kvar" );
                    Thread.Sleep(200);
                }

                Console.WriteLine();
                Console.ReadLine();

                #region för felsök
                /*
                foreach (KeyValuePair<string, string> item in stats)
                {
                    Console.WriteLine(item.Key + item.Value);
                }
                */
                #endregion

                // Tar bort nuvarande kp...
                RSID("spelare", "kp", ";", stats);
                // ...och lägger till nya.
                LSID("spelare", "kp" + kp + ";", stats);
            }
            else
            {
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteGreen("\r" + resultat + " > " + cl);
                    Thread.Sleep(200);
                }

                Console.WriteLine("Misslyckas");
            }
        }

        static void SpelarAttack()
        {
            Random rnd = new Random();

            string vapenPaket = SSID("spelare", "va", ";", stats);
            Console.WriteLine(vapenPaket);
            string[] vapen = vapenPaket.Split('¤');

            MenyPrint(vapen);
        }

        static string[] blanda(string[] inputs)
        {
            List<string> sortera = new List<string>();
            Random rnd = new Random();

            for (int i = 0; i < inputs.Length; i++)
            {
                sortera.Add(rnd.Next(0, 100) + "¤" + inputs[i]);
            }

            sortera.Sort();
            string[] outputs = new string[inputs.Length];
            int a = 0;

            foreach (string item in sortera)
            {
                string[] split = item.Split('¤');

                outputs[a] = split[1];
                a++;
            }

            return outputs;
        }

        static string SSID(string sökNyckel, string startOrd, string stopOrd, Dictionary<string,string> dic)
        {
            // Sök substring i dictionary

            int sökPlats;
            int start = 0;
            int stop = 0;

            string returString = "";

            foreach (KeyValuePair<string, string> föremål in dic)
            {
                if (sökNyckel == föremål.Key)
                {
                    sökPlats = 0;
                    while (true)
                    {
                        start = föremål.Value.IndexOf(startOrd, sökPlats);
                        // IndexOf returnerar -1 ifall inte hittar något, isåfall break;
                        if (start == -1)
                            break;
                        else
                            start = start + startOrd.Length;

                        stop = föremål.Value.IndexOf(stopOrd, start);
                        sökPlats = stop;

                        string resultat = föremål.Value.Substring(start, stop - start);
                        returString = returString + resultat + "¤";
                    }
                }
            }
            if (returString == "")
            {
                returString = "null";
            }
            else
            {
                // Tar bort sista ¤
                returString = returString.Remove(returString.Length - 1);
            }

            return returString;
        }

        static void RSID(string sökNyckel, string startOrd, string stopOrd, Dictionary<string, string> dic)
        {
            // Radera substring i dictionary

            int sökPlats;
            int start = 0;
            int stop = 0;

            string resultat = "";

            foreach (KeyValuePair<string, string> föremål in dic)
            {
                if (sökNyckel == föremål.Key)
                {
                    sökPlats = 0;
                    while (true)
                    {
                        start = föremål.Value.IndexOf(startOrd, sökPlats);
                        // IndexOf returnerar -1 ifall inte hittar något, isåfall break;
                        if (start == -1)
                            break;
                        else
                            start = start + startOrd.Length;

                        stop = föremål.Value.IndexOf(stopOrd, start);
                        sökPlats = stop;

                        // Start-2 för att ta bort identifierare t.ex "VA eller BE" och sedan +3 för att få bort ";".
                        resultat = föremål.Value.Remove(start-2, stop - start+3);

                    }
                }
            }
            dic.Remove(sökNyckel);
            dic.Add(sökNyckel, resultat);
        }

        static void LSID(string nyckel, string attLäggaTill, Dictionary<string,string> dic)
        {
            // Lägg till substring i dictionary
            string värde = "";

            foreach (KeyValuePair<string,string> item in dic)
            {
                if (item.Key == nyckel)
                {
                    värde = item.Value + attLäggaTill;
                }
            }
            dic.Remove(nyckel);
            dic.Add(nyckel, värde);

        }

        static void TärningAnimation()
        {

            #region tärning animation
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("::");
            Console.ResetColor();
            Thread.Sleep(500);
            int temp = 0;
            for (int i = 0; i < 10; i++)
            {
                temp++;
                Console.Write("\r");
                

                for (int a = 0; a < i; a++)
                {
                    Console.Write(" ");
                }
                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                switch (temp)
                {
                    case 1:
                        Console.Write("/");
                        break;

                    case 2:
                        Console.Write("-");
                        break;

                    case 3:
                        Console.Write("\\");
                        break;

                    case 4:
                        Console.Write("-");
                        temp = 0;
                        break;

                    default:
                        break;
                }
                Console.ResetColor();
                Console.Write(" ");
                Thread.Sleep(100);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("\r::");
            Console.ResetColor();
            #endregion
        }
        static void Initiativ(string fiendeTyp)
        {
            int fiendeVärde = 0;
            int spelarVärde = 0;

            Random rnd = new Random();
            int randomInitiativ;

            Console.Write(fiendeTyp + " har en ");
            randomInitiativ = rnd.Next(0, 2);
            switch (randomInitiativ)
            {
                case 0:
                    fiendeVärde = KastaTärning("1t10", "defensiv");
                    WriteBlue("|defensiv|");
                    break;

                case 1:
                    fiendeVärde = KastaTärning("1t10", "offensiv");
                    WriteRed("|offensiv|");
                    break;

                case 2:
                    fiendeVärde = KastaTärning("1t10", "neutral");
                    WriteGreen("|neutral|");
                    break;

                default:
                    break;
            }
            Console.WriteLine(" position!");

            MenyPrint("Defensiv", "Offensiv", "Neutral");

            switch (Console.ReadLine())
            {
                case "1":
                    spelarVärde = KastaTärning("1t10", "defensiv");
                    WriteBlue("|defensiv|");
                    break;

                case "2":
                    spelarVärde = KastaTärning("1t10", "offensiv");
                    WriteRed("|offensiv|");
                    break;

                case "3":
                    spelarVärde = KastaTärning("1t10", "neutral");
                    WriteGreen("|neutral|");
                    break;

                default:
                    Console.WriteLine("du skrev något kefft försök igen");
                    break;
            }

            Console.WriteLine(spelarVärde + " / " + fiendeVärde);

            Console.ReadLine();

            // borde returnera namnet på den som ska börja

            // skriv intiativ position
            // låt spelare välja
            // slå tärningar
            // jämför och låt den med högst börja  
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
                        WriteGreen("|::| = " + KastaTärning("1t100").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "2":
                        WriteGreen("|::| = " + KastaTärning("1t10").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "3":
                        WriteGreen("|::| = " + KastaTärning("1t20").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "4":
                        WriteGreen("|::| = " + KastaTärning("1t6").ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;

                    case "5":
                        WriteRed("Lämnar en episk tärningssimulator");
                        break;

                    default:
                        WriteGreen("|::| = " + KastaTärning(inmat).ToString() + "\n");
                        Console.Write("Klicka ");
                        WriteBlue("Enter");
                        Console.WriteLine(" för att gå vidare");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("slut på sim");
            }
        }

        #region meny
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

        static void MenyPrint(string[] val)
        {
            Console.WriteLine("--->============>");
            for (int i = 1; i < val.Length; i++)
            {
                WriteBlue("|" + i.ToString() + "| ");
                Console.WriteLine(val[(i-1)]);
                Thread.Sleep(200);

            }
            Console.WriteLine("--->============>");
        }
        #endregion

        #region tärning
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

        static int KastaTärning(string tärningsData, string initiativ)
        {
            string[] dataSplit = tärningsData.Split('t');
            Random random = new Random();
            int värde = 0;

            for (int i = 0; i < int.Parse(dataSplit[0]); i++)
            {
                värde = värde + random.Next(0, int.Parse(dataSplit[1]));
            }


            switch (initiativ)
            {
                case "defensiv":
                    värde = värde - 3;
                    break;

                case "offensiv":
                    värde = värde + 3;
                    break;

                case "neutral":
                    värde = värde - 3;
                    break;

                default:
                    break;
            }

            return värde;
        }
        #endregion

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
        static void WriteGrey(string textGrey)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(textGrey);
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion


    }
}
