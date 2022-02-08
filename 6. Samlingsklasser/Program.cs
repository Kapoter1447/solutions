// See https://aka.ms/new-console-template for more information

//
#region initiering och deklarering

string answer = "";
string answer2 = "";

string glosaS = "";
string glosaE = "";

Dictionary<string, string> ord = new Dictionary<string, string>()
{
    {"din mamma", "är cool"},
    {"bror", "cool"},

};


#endregion




Console.WriteLine("Glosförhör \nVill du skriva in egna glosor?");
writeRed("ja/nej: ");


while (answer != "nej")
{
    answer = Console.ReadLine();

    switch (answer)
    {
        case "ja":
            Console.Write("Skriv ");
            writeRed("avsluta");
            Console.WriteLine(" för att avsluta");


            while (glosaE != "avsluta" && glosaS != "avsluta")
            {
                Console.Write("Skriv ord på ");
                writeGreen("Svenska: ");
                glosaS = Console.ReadLine();

                Console.Write("Skriv ord på ");
                writeGreen("Engelska: ");
                glosaE = Console.ReadLine();

                ord.Add(glosaS, glosaE);

                writeGreen("Glosa tillagd\n");
            }
            answer = "nej";
            break;

        case "nej":
            break;

        default:
            Console.WriteLine("Fel vid inmat. Försök igen");
            break;
    }
}

Console.WriteLine("Bestäm inmat språk s/e");

string språk = "";

while (språk != "s" && språk != "e")
{
    språk = Console.ReadLine();

    switch (språk)
    {
        case "s":
            Console.WriteLine("Du valde inmat på svenska");
            break;

        case "e":
            Console.WriteLine("Du valde inmat på engelska");
            break;

        default:
            Console.WriteLine("Fel vid inmat. Försök igen");
            break;
    }
}



Console.WriteLine();
    
foreach(KeyValuePair<string,string> temp in ord)
{
    Console.WriteLine("Skriv in språk på: " + språk);

   // Console.WriteLine("{0} {1}", temp.Key, temp.Value);

    Console.WriteLine(temp.Value);

    string inmat = Console.ReadLine();

    if (inmat == temp.Key)
    {
        Console.WriteLine("rätt");
    }

    Console.WriteLine();
}
    
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

//skriv någon contain grej för nummer
