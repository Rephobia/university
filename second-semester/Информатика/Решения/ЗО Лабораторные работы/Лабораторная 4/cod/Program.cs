using System;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение x");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите значение n");

        int n = Int32.Parse(Console.ReadLine());
        double r = 1;

        for (int i = 0; i <= n; i++) {
            r *= Math.Pow(Math.Sin(x), i) + 1/Math.Sqrt(x);

            if (i % 4 == 0) {
                Console.WriteLine(r);
            }
        }
        Console.WriteLine("Для завершения нажмите любую кнопку");
        Console.ReadKey();
    }
}

