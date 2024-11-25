using System;

internal class Program
{
    static void Main(string[] args)
    {
        uint myNumber = 5;
        uint k = 14;
        uint result = myNumber % k;
        if (result == 0)
        {
            result = k;
        }
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
