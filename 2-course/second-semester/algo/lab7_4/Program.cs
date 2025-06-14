using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите десятичное число: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Введите основание системы (2-9): ");
        int baseN = int.Parse(Console.ReadLine());

        if (baseN < 2 || baseN > 9)
        {
            Console.WriteLine("Основание должно быть от 2 до 9.");
            return;
        }

        string result = ConvertToBaseN(number, baseN);
        Console.WriteLine($"Число {number} в системе счисления с основанием {baseN}: {result}");
    }

    static string ConvertToBaseN(int number, int baseN)
    {
        if (number < baseN)
            return number.ToString();
        else
            return ConvertToBaseN(number / baseN, baseN) + (number % baseN).ToString();
    }
}
