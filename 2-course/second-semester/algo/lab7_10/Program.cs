using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());

        int gcd = GCD(Math.Abs(a), Math.Abs(b));
        if (gcd == 1)
            Console.WriteLine("Числа взаимно простые.");
        else
            Console.WriteLine("Числа НЕ взаимно простые.");
    }

    static int GCD(int a, int b)
    {
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }
}
