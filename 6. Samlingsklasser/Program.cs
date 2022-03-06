
#region initiering och deklarering

string inmat = "";

string glosaK = "";
string glosaV = "";

// Default språk
string språkKey = "svenska";
string språkValue = "engelska";


Dictionary<string, string> glosor = new Dictionary<string, string>()
{
    // Default glosor. I början är keys svenska och values engelska.
    {"hund", "dog"},
    {"moder", "mother"},
    {"jag skall icke vara rädd", "i must not fear"},
    {"rädsla är sinnesdödaren", "fear is the mindkiller"},
    {"dubbla svärd", "akimbo swords"},
    {"närliggande", "adjacent"},
};

Dictionary<string, string> nuvarandeGlosor = new Dictionary<string, string>();

Dictionary<string, string> resultat = new Dictionary<string, string>();


#endregion

#region val
while (inmat != "4")
{
    #region meny och statistik
    Console.WriteLine("---------------------");
    Console.WriteLine("GLOSFÖRHÖR!");
    writeBlue("1. ");
    Console.WriteLine("Starta glosförhör");
    writeBlue("2. ");
    Console.WriteLine("Se glosor");
    writeBlue("3. ");
    Console.WriteLine("Bestäm språk");
    writeBlue("4. ");
    Console.WriteLine("Avsluta program");
    Console.WriteLine("---------------------");

    Console.Write("\nSpråk: ");
    writeGreen(språkKey + " + " + språkValue);

    Console.Write("\nGlosor: ");
    writeGreen(glosor.Count.ToString() + "\n");

    Console.WriteLine("\nResultat senaste förhöret: ");
    int antalFel = 0;
    foreach (KeyValuePair<string,string> svar in resultat)
    {
        if (svar.Value == "rätt")
            antalFel++;
    }
    writeGreen(antalFel.ToString());
    Console.Write("/" + nuvarandeGlosor.Count.ToString() + "\n");

    inmat = Console.ReadLine();
    #endregion

    switch (inmat)
    {
        case "4":
            Console.WriteLine("Program avslutat");
            Thread.Sleep(800);
            break;

        case "3":
            Console.Clear();

            Console.Write("Nuvarande språk: ");
            writeGreen(språkKey);
            Console.Write(" och ");
            writeGreen(språkValue);
            Console.WriteLine();

            Console.WriteLine("Skriv in språk 1: ");
            språkKey = Console.ReadLine();
            Console.WriteLine("Skriv in språk 2: ");
            språkValue = Console.ReadLine();

            Console.Clear();
            break;


        case "2":
            Console.Clear();
            seGlosor();
            Console.Clear();
            break;

        case "1":
            nuvarandeGlosor.Clear();
            resultat.Clear();
            foreach (KeyValuePair<string,string> glosa in glosor)
            {
                nuvarandeGlosor.Add(glosa.Key, glosa.Value);
            }
            Console.Clear();
            väljInmatSpråk();
            Console.Clear();
            break;

        case "easter egg":
            Console.Clear();

            Console.WriteLine("https://kapoter1447.itch.io/friend-simulator-it-is-not-real");
            Thread.Sleep(2000);

            Console.Clear();

            break;

        default:
            writeRed("\nFel vid inmat. Försök igen");
            Thread.Sleep(800);
            Console.Clear();
            break;
    }

}
#endregion

void väljInmatSpråk()
{
    Console.WriteLine("Bestäm språk för inmat: ");
    writeBlue(språkValue);
    Console.Write(" / ");
    writeBlue(språkKey);
    Console.WriteLine();

    inmat = Console.ReadLine();

    if (inmat == språkKey)
        förhör2(språkKey);

    else if (inmat == språkValue)
        förhör2(språkValue);

    else
        writeRed("\nFel vid inmat. Försök igen");
        Thread.Sleep(800);
}

void förhör2(string valtSpråk)
{
    blanda();

    foreach (KeyValuePair<string, string> glosa in nuvarandeGlosor)
    {
        // value är engelska och key är svenska som default

        Console.Clear();

        Console.Write("Skriv in språk på ");
        writeGreen(valtSpråk + "\n");

        // Förhör på språk 1
        if (valtSpråk == språkKey)
        {
            Console.Write(glosa.Value + " = ");
            string inmat = Console.ReadLine();

            if (inmat == glosa.Key)
            {
                writeGreen("Rätt!");
                
                resultat.Add(glosa.Key, "rätt");
                Thread.Sleep(500);

            }
            else
            {
                writeRed("Fel.");
                
                resultat.Add(glosa.Key, "fel");
                
                Console.Write("\n\nRätt svar var ");
                writeGreen(glosa.Key);

                Console.ReadLine();
            }
        }
        // Förhör på språk 2
        else if (valtSpråk == språkValue)
        {
            Console.Write(glosa.Key + " = ");
            string inmat = Console.ReadLine();

            if (inmat == glosa.Value)
            {
                writeGreen("Rätt!");
                
                resultat.Add(glosa.Key, "rätt");
                Thread.Sleep(500);
            }
            else
            {
                writeRed("Fel.");
                
                resultat.Add(glosa.Key, "fel");
     
                Console.Write("\n\nRätt svar var ");
                writeGreen(glosa.Value);

                Console.ReadLine();
            }
        }
    }

    #region visa resultat
    while (inmat != "2")
    {
        Console.Clear();
        Console.WriteLine("RESULTAT!\n ");
        Console.WriteLine("Svar:");

        foreach (KeyValuePair<string, string> svar in resultat)
        {
            if (svar.Value == "rätt")
            {
                foreach (KeyValuePair<string, string> glosa in glosor)
                {
                    if (svar.Key == glosa.Key)
                        writeGreen(glosa.Key + " = " + glosa.Value + "\n");
                }
            }
            else if (svar.Value == "fel")
            {
                foreach (KeyValuePair<string,string> glosa in glosor)
                {
                    if (svar.Key == glosa.Key)
                        writeRed(glosa.Key + " = " + glosa.Value + "\n");
                }
            }
            Thread.Sleep(100);
        }

        Console.WriteLine("\n---------------------");
        writeBlue("1. ");
        Console.WriteLine("Spela med felaktiga glosor");
        writeBlue("2. ");
        Console.WriteLine("Avsluta");
        Console.WriteLine("---------------------");
        inmat = Console.ReadLine();

        switch (inmat)
        {
            case "1":
                nuvarandeGlosor.Clear();
                foreach(KeyValuePair<string, string> svar in resultat)
                {
                    if (svar.Value == "fel")
                    {
                        foreach (KeyValuePair<string,string> glosa in glosor)
                        {
                            if (glosa.Key == svar.Key)
                            {
                                nuvarandeGlosor.Add(glosa.Key, glosa.Value);
                            }
                        }
                    }
                }
                resultat.Clear();
                förhör2(valtSpråk);
                break;

            case "2":
                break;
            
            default:
                writeRed("\nFel vid inmat. Försök igen");
                Thread.Sleep(800);
                break;
        }
    }
    #endregion
}

void seGlosor()
{
    while (inmat != "3")
    {
        Console.WriteLine("GLOSOR!");
        writeGreen(språkKey + ":   " + språkValue + ":\n\n");
        foreach (KeyValuePair<string, string> print in glosor)
        {
            Console.WriteLine(print.Key + " = " + print.Value);
            Thread.Sleep(100);
        }
        Console.WriteLine("\n------------------");
        writeBlue("1. ");
        Console.WriteLine("Lägg till glosor");
        writeBlue("2. ");
        Console.WriteLine("Radera glosor");
        writeBlue("3. ");
        Console.WriteLine("Avsluta");
        Console.WriteLine("------------------");

        inmat = Console.ReadLine();

        switch (inmat)
        {
            case "1":
              Console.Clear();
              nyaGlosor();
              Console.Clear();
              break;

            case "2":
                Console.Clear();
                raderaGlosa();
                Console.Clear();
                break;

            case "3":
                break;

            default:
                writeRed("Fel inmat. Försök igen.");
                Thread.Sleep(800);
                Console.Clear();
                break;
        }
    }
}

void nyaGlosor()
{
    Console.Write("Skriv ");
    writeBlue("1");
    Console.WriteLine(" för att avsluta");
    writeRed("Ifall samma glosa skrivs in flera gånger skrivs den över\n");


    while (glosaV != "1")
    {
        Console.Write("Skriv glosor på ");
        writeGreen(språkKey + ": ");
        glosaK = Console.ReadLine();

        if (glosaK == "1")
        {
            break;
        }
        else
        {
            Console.Write("Skriv glosor på ");
            writeGreen(språkValue + ": ");
            glosaV = Console.ReadLine();

            // Tar bort för att skriva över
            glosor.Remove(glosaK);
            glosor.Add(glosaK, glosaV);

            writeGreen("Glosa tillagd\n");


        }
    }
}

void raderaGlosa()
{
    Console.WriteLine("Glosor:\n");
    foreach (KeyValuePair<string, string> print in glosor)
    {
        Console.WriteLine(print.Key);
        
        Thread.Sleep(50);
    }

    writeRed("\nSkriv namnet på ");
    writeGreen(språkKey);
    writeRed(" för att radera: ");
    
    glosor.Remove(Console.ReadLine());

}

void blanda()
{
    //blandar dictionaryn "nuvarandeGlosor"

    List<string> sortera = new List<string>();
    Random rnd = new Random();

    foreach (KeyValuePair<string,string> glosa in nuvarandeGlosor)
    {
        sortera.Add(rnd.Next(1,100) + "¤" + glosa.Key + "¤" + glosa.Value);
    }
    nuvarandeGlosor.Clear();
    sortera.Sort();

    foreach (string temp in sortera)
    {
        string[] blandadeGlosor = temp.Split('¤');
        nuvarandeGlosor.Add(blandadeGlosor[1], blandadeGlosor[2]);
    }

}

#region färger
void writeRed(string textRöd)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(textRöd);
    Console.ForegroundColor = ConsoleColor.White;

}
void writeGreen(string textGreen)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(textGreen);
    Console.ForegroundColor = ConsoleColor.White;

}
void writeBlue(string textBlue)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(textBlue);
    Console.ForegroundColor = ConsoleColor.White;

}
#endregion

//skriv någon contain grej för nummer
