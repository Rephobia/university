using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число a");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число b");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число c");
        int c = Convert.ToInt32(Console.ReadLine());

        int result = 0;
        if (a <= 0 && b <= 0 && c <= 0)
        {
            result = 3;
        } 
        else if ((a <= 0 && b <= 0) || (a <= 0 && c <= 0) || (b <= 0 && c <= 0))
        {
            result = 2;
        } else if (a <= 0 || b <= 0 || c <= 0) 
        {
            result = 1;
        }

        Console.WriteLine("Количество неположительных чисел: " +  result);
        Console.ReadKey();
    }
}
