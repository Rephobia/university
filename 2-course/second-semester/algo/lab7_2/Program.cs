using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число a (основание): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите целое неотрицательное число n (степень): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0)
        {
            Console.WriteLine("Степень должна быть неотрицательной.");
            return;
        }

        int result = Power(a, n);
        Console.WriteLine($"{a}^{n} = {result}");
    }

    static int Power(int a, int n)
    {
        if (n == 0)
            return 1;
        return a * Power(a, n - 1);
    }
}
