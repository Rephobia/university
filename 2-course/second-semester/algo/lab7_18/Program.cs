using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число (x): ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Введите второе число (y): ");
        int y = int.Parse(Console.ReadLine());

        if (x == 0 && y == 0)
        {
            Console.WriteLine("НОД не определён для двух нулей.");
            return;
        }

        int result = GCD(x, y);
        Console.WriteLine($"НОД({x}, {y}) = {result}");
    }

    static int GCD(int x, int y)
    {
        if (y == 0)
            return x;
        return GCD(y, x % y);
    }
}
