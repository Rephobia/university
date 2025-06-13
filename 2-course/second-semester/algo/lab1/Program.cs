using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число x:");
        double x = Convert.ToDouble(Console.ReadLine());

        double a = 2.5;
        double b = 1.5;
        double e = Math.E;

        double y = (x * Math.Pow(Math.Sin(Math.Pow(a + x, 2)), 2)) - Math.Pow(Math.Abs(x - a), 1 / 3) + Math.Log(Math.Pow(x - b, 2) + 1);

        double f = Math.Sqrt(Math.Pow(a * x, 2) + x) + Math.Pow(a * e, a * e * -1) + Math.Log(Math.Abs(1 - x) + 1);

        Console.WriteLine($"y = {y}");
        Console.WriteLine($"f = {f}");
    }
}
