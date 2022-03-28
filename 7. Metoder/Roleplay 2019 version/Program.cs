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

            {"spelare","kp1; vagitta away; vadin döda farfarsfars stridsyxa; vam9 beretta 9x19mm 380m/s akimbo pistol; cl50; "},
            {"mattant","kp6; vamorotssoppa; cl40; vastor slev;"},
            {"rektorn","kp200; vaen helvetes penna; cl100;"}

        };

        static Dictionary<string, string> standardVärde = new Dictionary<string, string>();

        static Dictionary<string, string> attacker = new Dictionary<string, string>()
        {
            {"rå styrka", "DA1t3; BEAttackerar med näven;"  },
            {"stor slev", "DA1t6; BEbeskrivning till stor slev;" },
            {"morotssoppa", "DA2t6; BEMattanten tar fram sin onda kittel och börjar brygga en stinkande orange vätska. Du ryggar av stanken av det giftigaste på jordens yta tillagas framför dig. Helt plötsligt tar mattanten en slev med morotsoppa och kastar mot dig!;" },
            {"m9 beretta 9x19mm 380m/s akimbo pistol", "DA4t6; BEKapoowww!! Pang pang!;"},
            {"din döda farfarsfars stridsyxa", "DA1t2; BEDu tar fram din döda farfarsfars stridsyxa. Genom åren har den blivit sliten och det enda som återstår är skaftet. Den är i princip värdelös, men du attackerar ändå.; "}
        };


        static void Main(string[] args)
        {
            // Sparar standardvärden:
            foreach (KeyValuePair<string, string> item in stats)
            {
                standardVärde.Add(item.Key, item.Value);
            }

            Console.CursorVisible = false;

            string inmat = "";

            while (inmat != "3")
            {
                Console.Clear();
                
                TärningAnimation();
                WriteGreen(" = Programmering och demoner\n");
                Thread.Sleep(1000);
                
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


                    case "streckgubbe":
                        Streckgubbe("glad");
                        break;

                    case "easter egg2":
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine();

                            TärningAnimation();
                        }

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

            /*
            // Laddar in standarvärden
            stats.Clear();
            foreach (KeyValuePair<string,string> item in standardVärde)
            {

            }
            */


            /*
            RSID(fiendetyp, "kp", ";", stats);
            LSID(fiendetyp, "kp" + fiendeKp + ";", stats);
            */


            Console.WriteLine("Å nej bla bla bla har hänt! Helvete! \nAAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaah en mattant");
        
            if (Slåss("mattant"))
            {
                Console.WriteLine("Äventyret fortsätter...");
            }
   
            // kasta hårda och torra falaflar. förgifta med morotsoppa.

           // MenyPrint("Använd din döda farfarsfars stridsyxa", "Använd m9 beretta 9x19mm 380m/s akimbo pistol", "gitta away", "Checka stats");

            Console.ReadLine();

        }

        static bool Slåss(string fiendeTyp)
        {
            string[] aktörPositioner = Initiativ(fiendeTyp).Split("¤");
            string spelarInitiativ = aktörPositioner[2];
            string fiendeInitiativ = aktörPositioner[1];
            string startAktör = aktörPositioner[0];

            int spelarKp = int.Parse(SSID("spelare", "kp", ";", stats));
            int fiendeKp = int.Parse(SSID(fiendeTyp, "kp", ";", stats));

            Console.WriteLine(spelarKp);
            Console.WriteLine(fiendeKp);


            switch (startAktör)
            {
                case "fiende":
                    while (spelarKp > 0 && fiendeKp > 0)
                    {
                        if (fiendeKp > 0)
                        {
                            FiendeAttack(fiendeTyp, spelarInitiativ, fiendeInitiativ);
                            spelarKp = int.Parse(SSID("spelare", "kp", ";", stats));
                        }
                        if (spelarKp > 0)
                        {
                            SpelarAttack(fiendeTyp, spelarInitiativ, fiendeInitiativ);
                            fiendeKp = int.Parse(SSID(fiendeTyp, "kp", ";", stats));
                        }
                    }
                    Console.Clear();
                    break;

                case "spelare":
                    while (spelarKp > 0 && fiendeKp > 0)
                    {
                        if (spelarKp > 0)
                        {
                            SpelarAttack(fiendeTyp, spelarInitiativ, fiendeInitiativ);
                            fiendeKp = int.Parse(SSID(fiendeTyp, "kp", ";", stats));
                        }
                        if (fiendeKp > 0)
                        {
                            FiendeAttack(fiendeTyp, spelarInitiativ, fiendeInitiativ);
                            spelarKp = int.Parse(SSID("spelare", "kp", ";", stats));
                        }
                    }
                    Console.Clear();
                    break;

                default:
                    break;
            }

            if (fiendeKp <= 0)
            {
                Streckgubbe("glad");
                return true;
            }
            else
            {
                Streckgubbe("död");
                return false;
            }

            string vapenPaket = SSID(fiendeTyp, "va", ";", stats);
            string[] vapen = vapenPaket.Split('¤');
            string attLäggaTill;

            for (int i = 0; i < vapen.Length; i++)
            {
                attLäggaTill = "va" + vapen[i] + ";";
                LSID("spelare", attLäggaTill, stats);
            }
        }


        static void FiendeAttack(string fiendetyp, string spelarInitiativ, string fiendeInitiativ)
        {
            Console.Clear();

            #region slumpa attack
            // Letar upp alla attacker/vapen "fiendetyp" kan använda. Sedan blandas dessa och väljer en. Ifall inte returnerar något vapen, kör hand attack.
            string vapenPaket = SSID(fiendetyp, "va", ";", stats);
            string[] vapen = vapenPaket.Split('¤');
            string[] blandadeVapen = blanda(vapen);
            string aktivtVapen = blandadeVapen[0];
            #endregion

            WriteRed(fiendetyp.ToUpper() + " ATTACKERAR! \n");
            WriteGrey(SSID(aktivtVapen, "BE", ";", attacker) + "\n");

            Thread.Sleep(1000);

            #region cl
            int fiendeCl = int.Parse(SSID(fiendetyp, "cl", ";", stats));

            Console.WriteLine("\n-----------------------------------");
            Console.Write(fiendetyp + " cl: " );
            WriteBlue(fiendeCl + "%\n");
            Console.Write("Din position: ");
            switch (spelarInitiativ)
            {
                case "defensiv":
                    WriteBlue("|defensiv| -20%");
                    WriteGrey(" (Höjer ditt försvar)");
                    fiendeCl = fiendeCl - 20;
                    break;

                case "offensiv":
                    WriteRed("|offensiv| +20%");
                    WriteGrey(" (Sänker ditt försvar)");
                    fiendeCl = fiendeCl + 20;
                    break;

                case "neutral":
                    WriteGreen("|neutral| +0%");
                    break;

                default:
                    break;
            }
            Console.Write("\n" + fiendetyp + "position: ");
            switch (fiendeInitiativ)
            {
                case "defensiv":
                    WriteBlue("|defensiv| -20%");
                    WriteGrey(" (Försämrar fiendes attack)");
                    fiendeCl = fiendeCl - 20;
                    break;

                case "offensiv":
                    WriteRed("|offensiv| +20%");
                    WriteGrey(" (Förbättrar fiendes attack)");
                    fiendeCl = fiendeCl + 20;
                    break;

                case "neutral":
                    WriteGreen("|neutral| +0%");
                    break;

                default:
                    break;
            }

            Console.Write("\n\n = " + fiendetyp + " har ");
            WriteBlue(fiendeCl + "% ");
            Console.Write("att lyckas");
            Console.WriteLine("\n-----------------------------------");

            Thread.Sleep(1000);
            #endregion

            #region kollar ifall lyckas
            MenyPrint("'Enter' för att slå tärning (1t100)");
            Console.ReadLine();
            TärningAnimation();

            int resultat = KastaTärning("1t100");
            WriteGreen(" = " + resultat);

            if (resultat < fiendeCl)
            {
                #region lyckas
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + resultat + " < " + fiendeCl );
                    Thread.Sleep(200);
                }
                WriteRed("\n" + fiendetyp + " lyckas med attacken.\n");

                // ta med initativ

                // Kolla skada. Hitta spelar kp och ta kp - skada. Ta sedan bort nuvarnade kp substräng och sen skapa en ny med nya kp:t.
                int spelarKp = int.Parse(SSID("spelare", "kp", ";", stats));
                string tärningSkada = SSID(aktivtVapen, "DA", ";", attacker);

                Console.Write("\nDu har ");
                WriteBlue(spelarKp.ToString());
                Console.Write(" kp.\n");

                Console.Write(aktivtVapen + " gör ");
                WriteBlue(tärningSkada);
                Console.Write(" skada.\n");

                MenyPrint("'Enter' för att slå tärning för skada");
                Console.ReadLine();
                TärningAnimation();
                
                int skada = KastaTärning(tärningSkada);
                int kpInnan = spelarKp;
                spelarKp = spelarKp - skada;

                WriteRed(" = " + skada);
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + kpInnan + "kp - " + skada + "skada = " + spelarKp + "kp kvar" );
                    Thread.Sleep(200);
                }

                Console.WriteLine();

                // Tar bort nuvarande kp...
                RSID("spelare", "kp", ";", stats);
                // ...och lägger till nya.
                LSID("spelare", "kp" + spelarKp + ";", stats);

                #endregion
            }
            else
            {
                #region misslyckas
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteGreen("\r" + resultat + " > " + fiendeCl);
                    Thread.Sleep(200);
                }

                WriteGreen("\n Du parerar attacken och " + fiendetyp + " misslyckas med attack!");
                #endregion
            }
            #endregion

            Console.WriteLine("\n 'Enter' för att gå vidare");
            Console.ReadLine();
            Console.Clear();
        }

        static void SpelarAttack(string fiendetyp, string spelarInitiativ, string fiendeInitiativ)
        {
            // beskrivning
            // cl
            // slå tärningar

            string inmat = "";

            Console.Clear();
            WriteGreen("SPELARE ATTACKERAR\n");

            #region välja vapen
            string vapenPaket = SSID("spelare", "va", ";", stats);
            string[] vapen = vapenPaket.Split('¤');
            string aktivtVapen = "";
            MenyPrint(vapen);

            // Det är hårdkodat hur många vapen man kan välja här

            inmat = Console.ReadLine();

            while (aktivtVapen == "")
            {
                aktivtVapen = vapen[int.Parse(inmat)-1];
            }

            WriteGrey(SSID(aktivtVapen, "BE", ";", attacker)+"\n");
            #endregion

            #region cl
            int spelarCl = int.Parse(SSID("spelare", "cl", ";", stats));

            Console.WriteLine("\n-----------------------------------");
            Console.Write("Spelare cl: ");
            WriteBlue(spelarCl + "%\n");
            Console.Write("Din position: ");
            switch (spelarInitiativ)
            {
                case "defensiv":
                    WriteBlue("|defensiv| -20%");
                    WriteGrey(" (Sänker din chans att lyckas vid attack)");
                    spelarCl = spelarCl - 20;
                    break;

                case "offensiv":
                    WriteRed("|offensiv| +20%");
                    WriteGrey(" (Höjer din chans att lyckas vid attack)");
                    spelarCl = spelarCl + 20;
                    break;

                case "neutral":
                    WriteGreen("|neutral| +0%");
                    break;

                default:
                    break;
            }
            Console.Write("\n" + fiendetyp + "position: ");
            switch (fiendeInitiativ)
            {
                case "defensiv":
                    WriteBlue("|defensiv| -20%");
                    WriteGrey(" (Förbättrar fiendes försvar)");
                    spelarCl = spelarCl - 20;
                    break;

                case "offensiv":
                    WriteRed("|offensiv| +20%");
                    WriteGrey(" (Försämrar fiendes försvar)");
                    spelarCl = spelarCl + 20;
                    break;

                case "neutral":
                    WriteGreen("|neutral| +0%");
                    break;

                default:
                    break;
            }

            Console.Write("\n\n = Du har ");
            WriteBlue(spelarCl + "% ");
            Console.Write("att lyckas");
            Console.WriteLine("\n-----------------------------------");

            Thread.Sleep(1000);
            #endregion

            #region kollar ifall lyckas
            MenyPrint("'Enter' för att slå tärning (1t100)");
            Console.ReadLine();
            TärningAnimation();

            int resultat = KastaTärning("1t100");
            WriteGreen(" = " + resultat);

            if (resultat < spelarCl)
            {
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteGreen("\r" + resultat + " < " + spelarCl);
                    Thread.Sleep(200);
                }
                WriteGreen("\nDu lyckas med attacken!\n");

                int fiendeKp = int.Parse(SSID(fiendetyp, "kp", ";", stats));
                string tärningSkada = SSID(aktivtVapen, "DA", ";", attacker);

                Console.Write("\n" + fiendetyp + " har ");
                WriteBlue(fiendeKp.ToString());
                Console.Write(" kp.\n");

                Console.Write(aktivtVapen + " gör ");
                WriteBlue(tärningSkada);
                Console.Write(" skada.\n");

                MenyPrint("'Enter' för att slå tärning för skada");
                Console.ReadLine();
                TärningAnimation();

                int skada = KastaTärning(tärningSkada);
                int kpInnan = fiendeKp;
                fiendeKp = fiendeKp - skada;

                WriteRed(" = " + skada);
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + kpInnan + "kp - " + skada + "skada = " + fiendeKp + "kp kvar");
                    Thread.Sleep(200);
                }

                Console.WriteLine();


                // Tar bort nuvarande kp...
                RSID(fiendetyp, "kp", ";", stats);
                // ...och lägger till nya.
                LSID(fiendetyp, "kp" + fiendeKp + ";", stats);


            }
            else
            {
                #region misslyckas
                Console.WriteLine("");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("\r                        ");
                    Thread.Sleep(200);
                    WriteRed("\r" + resultat + " > " + spelarCl);
                    Thread.Sleep(200);
                }
                WriteRed("\nDu misslyckas med attacken\n");
                #endregion
            }

            #endregion

            Console.ReadLine(); Console.WriteLine("\n 'Enter' för att gå vidare");
            Console.ReadLine();
            Console.Clear();
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
            Console.Write("\r::");
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
            Console.Write("\b\b\b::");
            Console.ResetColor();
            #endregion
        }

        static string Initiativ(string fiendeTyp)
        {
            int fiendeVärde = 0;
            int spelarVärde = 0;

            string spelarInitiativ = "";
            string fiendeInitiativ = "";

            string startAktör = "";

            Random rnd = new Random();
            int slumpInitiativ;

            Console.Write(fiendeTyp + " har en ");
            slumpInitiativ = rnd.Next(0, 2);
            switch (slumpInitiativ)
            {
                case 0:
                    fiendeVärde = KastaTärning("1t10", "defensiv");
                    fiendeInitiativ = "defensiv";
                    WriteBlue("|defensiv|");
                    break;

                case 1:
                    fiendeVärde = KastaTärning("1t10", "offensiv");
                    fiendeInitiativ = "offensiv";
                    WriteRed("|offensiv|");
                    break;

                case 2:
                    fiendeVärde = KastaTärning("1t10", "neutral");
                    fiendeInitiativ = "neutral";
                    WriteGreen("|neutral|");
                    break;

                default:
                    break;
            }
            Console.WriteLine(" position!\n");

            Console.Write("Välj position!");
            WriteGrey(" (Högst värde på 1t10 börjar)\n");
            MenyPrint("Defensiv -3", "Offensiv +3", "Neutral +0");
            switch (Console.ReadLine())
            {
                case "1":
                    spelarVärde = KastaTärning("1t10", "defensiv");
                    spelarInitiativ = "defensiv";
                   // WriteBlue("|defensiv|");
                    break;

                case "2":
                    spelarVärde = KastaTärning("1t10", "offensiv");
                    spelarInitiativ = "offensiv";
                 //   WriteRed("|offensiv|");
                    break;

                case "3":
                    spelarVärde = KastaTärning("1t10", "neutral");
                    spelarInitiativ = "neutral";
                  //  WriteGreen("|neutral|");
                    break;

                default:
                    Console.WriteLine("du skrev något kefft försök igen");
                    break;
            }
            Console.WriteLine("spelare poäng");
            TärningAnimation();
            WriteGreen(" = " + spelarVärde + "\n\n");

            Console.WriteLine(fiendeTyp + " poäng");
            TärningAnimation();
            WriteGreen(" = " + fiendeVärde);

            Console.WriteLine("\n");
            if (spelarVärde < fiendeVärde)
            {
                WriteRed(fiendeTyp + " börjar attackera!");
                startAktör = "fiende";
            }
            else if (spelarVärde > fiendeVärde || spelarVärde == fiendeVärde)
            {
                WriteGrey("Spelare börjar attackera!");
                startAktör = "spelare";
            }

            Console.ReadLine();

            return startAktör + "¤" + fiendeInitiativ + "¤" + spelarInitiativ;
        }

        static void Streckgubbe(string humör)
        {
            int delay = 100;

            if (humör == "glad")
            {
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
                WriteGreen("Du är en vinnare!!!");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else if (humör == "död")
            {
                Console.WriteLine(" ----- ");
                Thread.Sleep(delay);
                Console.WriteLine("| X X |");
                Thread.Sleep(delay);
                Console.WriteLine("| _-_ |");
                Thread.Sleep(delay);
                Console.WriteLine(" _____ ");
                Thread.Sleep(delay);
                Console.WriteLine("  |||  ");
                Thread.Sleep(delay);
                Console.WriteLine(" ||||| ");
                Thread.Sleep(delay);
                Console.WriteLine("¤--|--¤  ");
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
                WriteRed("Du är död noob");
                Thread.Sleep(2000);
                Console.Clear();
            }

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
            for (int i = 0; i < val.Length; i++)
            {
                WriteBlue("|" + (i+1).ToString() + "| ");
                Console.WriteLine(val[i]);
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
