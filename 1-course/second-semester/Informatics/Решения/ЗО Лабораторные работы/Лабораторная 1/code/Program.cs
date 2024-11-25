using System;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите радиус:");
        int R = Convert.ToInt32(Console.ReadLine());
        double S = Math.PI * R * R * 2;
        double P = Math.PI * R * 2 * 2;
        Console.WriteLine("Площадь фигуры: " + S);
        Console.WriteLine("Периметр фигуры: " + P);
        Console.ReadKey(); 
    }
}
