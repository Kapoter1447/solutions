

Console.WriteLine(moms(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));

// moms(vad vi vill mosma, moms i procet)

static double moms(double talAttMomsa, double procent)
{
    return talAttMomsa * (procent/100+1);
}


