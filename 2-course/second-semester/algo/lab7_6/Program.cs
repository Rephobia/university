using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первый член прогрессии (a1): ");
        int a1 = int.Parse(Console.ReadLine());

        Console.Write("Введите разность прогрессии (d): ");
        int d = int.Parse(Console.ReadLine());

        Console.Write("Введите количество членов (n): ");
        int n = int.Parse(Console.ReadLine());

        int sum = SumArithmeticProgression(a1, d, n);

        Console.WriteLine($"Сумма первых {n} членов арифметической прогрессии: {sum}");
    }

    static int SumArithmeticProgression(int a1, int d, int n)
    {
        if (n == 1)
            return a1;
        else
            return a1 + (n - 1) * d + SumArithmeticProgression(a1, d, n - 1);
    }
}
