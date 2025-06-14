using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите число b: ");
        int b = int.Parse(Console.ReadLine());

        int result = GCD(a, b);
        Console.WriteLine($"НОД({a}, {b}) = {result}");
    }

    static int GCD(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        if (a == 0) return b;
        if (b == 0) return a;

        if (IsEven(a) && IsEven(b))
            return 2 * GCD(a / 2, b / 2);

        if (IsEven(a) && !IsEven(b))
            return GCD(a / 2, b);

        if (!IsEven(a) && IsEven(b))
            return GCD(a, b / 2);

        if (a > b)
            return GCD((a - b) / 2, b);
        else
            return GCD((b - a) / 2, a);
    }

    static bool IsEven(int x)
    {
        return (x & 1) == 0;
    }
}
