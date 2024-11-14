using System;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число x");
        int x = int.Parse(Console.ReadLine());
        double y;
        int branchNumber;
        if (x < 0) {
            y = x + Math.Sin(x);
            branchNumber = 1;
        } else if (x > 0) {
            y = 5 + Math.Sqrt(Math.Pow(x, 5));
            branchNumber = 2;
        } else {
            y = Math.Pow(Math.E, x);
            branchNumber = 3;
        }
        Console.WriteLine("Номер ветви: " + branchNumber);
        Console.WriteLine("Результат вычислений: " + y);
        Console.WriteLine("Нажмите любую клавишу для выхода");
        Console.ReadKey();
    }
}