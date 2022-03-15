string inmat = "";
int delay = 100;

#region Stickman
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
#endregion

while (inmat != "3")
{
    MenyPrint("Spela äventyret \"Bob är kidnappad\"", "Tärnings simulator", "Avsluta");

    inmat = Console.ReadLine();

    switch (inmat)
    {
        case "1":
            break;

        case "2":
            TärningSimulator();
            break;

        case "3":
            break;

        case "4":
            break;

        default:
            WriteRed("Fel vid inmat. Försök igen.");
            Console.Clear();
            break;
    }


    inmat = Console.ReadLine();

    Console.WriteLine(KastaTärning(inmat)); 
        
}

void TärningSimulator()
{
}

#region MenyPrint 5 val 

static void MenyPrint5(string val1, string val2, string val3, string val4, string val5)
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
        WriteBlue(i.ToString());
        Console.WriteLine(val);
        i++;
    }
} 

#endregion

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
