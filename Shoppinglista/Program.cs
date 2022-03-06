// See https://aka.ms/new-console-template for more information

List<string> shoppinglista = new List<string>();
List<string> borttagnaVaror = new List<string>();
bool program = true;
string[] inmat;

Console.ResetColor();   
Console.WriteLine("'add' för lägg till vara\n" +
"'del' för radera vara \n" +
"'quit' för att avsluta\n" +
"'str' för att markera varan köpt" +
"'.' efter inmat");

while (program)
{
    inmat = Console.ReadLine().Split('.');

    switch (inmat[0])
    {
        case "add":
            add();
            break;
            
        case "del":
            delete();
            break;

        case "quit":
            program = false;
            break;

        case "str":
            strike();
            break;

        default:
            break;
    }
    
    skriv();

}

Console.WriteLine("Lista avslutad");


void skriv()
{
    Console.Clear();
    Console.ResetColor();
    Console.WriteLine("'add' för lägg till vara\n" +
    "'del' för radera vara \n" +
    "'quit' för att avsluta\n" +
    "'str' för att markera varan köpt" +
    "'.' efter inmat");

    Console.WriteLine("------------------------------------");

    Console.ForegroundColor = ConsoleColor.Magenta;
    foreach (string vara in shoppinglista)
    {
        Console.WriteLine(vara);
    }

    Console.ForegroundColor= ConsoleColor.Yellow;
    foreach (string item in borttagnaVaror)
    {
        Console.WriteLine(item);
    }

    Console.ResetColor();
    Console.WriteLine("------------------------------------");
}

void delete()
{
    if (inmat[1] == "all")
    {
        shoppinglista.Clear();
    }
    else
    {
        shoppinglista.Remove(inmat[1]);
    }
}

void add()
{
    shoppinglista.Add(inmat[1]);
}


void strike()
{
    foreach (string item in shoppinglista)
    {
        if (inmat[1] == item)
        {
            string temp = item;
            shoppinglista.Remove(item);
            borttagnaVaror.Add(item);

            break;
        }


    }


}