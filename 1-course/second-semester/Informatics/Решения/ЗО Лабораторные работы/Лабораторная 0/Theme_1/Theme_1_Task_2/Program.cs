using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();
        Console.WriteLine("Привет " + name + "!");
        Console.ReadKey();
    }
}
