using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первый член прогрессии (b1): ");
        double b1 = double.Parse(Console.ReadLine());

        Console.Write("Введите знаменатель прогрессии (q): ");
        double q = double.Parse(Console.ReadLine());

        Console.Write("Введите номер члена (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите i: ");
        int i = int.Parse(Console.ReadLine());

        Console.Write("Введите k: ");
        int k = int.Parse(Console.ReadLine());

        double nth = GetMember(b1, q, n);
        Console.WriteLine($"{n}-й член прогрессии: {nth}");

        double sumN = Sum(b1, q, n);
        Console.WriteLine($"Сумма первых {n} членов: {sumN}");

        double sumFromIToK = Sum(b1, q, k) - Sum(b1, q, i - 1);
        Console.WriteLine($"Сумма с {i}-го по {k}-й член: {sumFromIToK}");
    }

    static double GetMember(double b1, double q, int n)
    {
        if (n == 1) return b1;
        return q * GetMember(b1, q, n - 1);
    }

    static double Sum(double b1, double q, int n)
    {
        if (n == 0) return 0;
        return GetMember(b1, q, n) + Sum(b1, q, n - 1);
    }
}
