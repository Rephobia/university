using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите a:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите b:");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите c:");
        int c = Convert.ToInt32(Console.ReadLine());

        double y = Math.Sqrt(Math.Pow(Math.Abs(a), b) - 2) / b * (Math.Pow(c, 3) - 1);
        Console.WriteLine("Результат:"  + y);
        Console.ReadKey();
    }
}


