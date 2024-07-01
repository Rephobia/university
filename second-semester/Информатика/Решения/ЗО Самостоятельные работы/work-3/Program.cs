using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите коэффициент b");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите коэффициент c");
        double c = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите количество элементов n");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите первый элемент");
        double a = Convert.ToDouble(Console.ReadLine());

        double prevElement = a;
        for (int i = 0; i < n; i++)
        {
            double element = b * prevElement + c;
            prevElement = element;
            Console.WriteLine(element + "\t");
        }
        Console.ReadKey();
    }
}

