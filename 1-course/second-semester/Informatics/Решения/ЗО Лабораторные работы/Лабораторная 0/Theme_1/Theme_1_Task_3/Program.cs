using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine();

        Console.WriteLine("Введите название вашей учебной группы: ");
        string group = Console.ReadLine();

        Console.WriteLine("Введите название учебного заведения в которомо вы учитесь: ");
        string educationPlace = Console.ReadLine();

        Console.WriteLine(name + " " + group + " " + educationPlace);
        Console.ReadKey();
    }
}
