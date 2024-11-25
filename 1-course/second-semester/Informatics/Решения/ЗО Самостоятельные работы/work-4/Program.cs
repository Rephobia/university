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

        double firstCheck = Math.Pow(Math.Abs(a), b) - 2;
        double secondCheck = b * (Math.Pow(c, 3) - 1);

        while (firstCheck < 0 && secondCheck != 0)
        {
            Console.WriteLine("Данные не в области определения функции!");
            Console.WriteLine("Введите a:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите b:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите c:");
            c = Convert.ToInt32(Console.ReadLine());

            firstCheck = Math.Pow(Math.Abs(a), b) - 2;
            secondCheck = b * (Math.Pow(c, 3) - 1);
        }

        Console.WriteLine("Результат:");
        Console.WriteLine(Math.Sqrt(Math.Pow(Math.Abs(a), b) - 2) / b * (Math.Pow(c, 3) - 1));
        Console.ReadKey();
    }
}
