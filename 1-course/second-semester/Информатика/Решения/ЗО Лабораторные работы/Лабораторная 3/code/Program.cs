using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите порядковый номер карты в колоде");

        int k = Convert.ToInt32(Console.ReadLine());

        if (k < 6 || k > 14) {
            Console.WriteLine("Ошибка: Карта не существует в колоде");
        }
        else {
            if (k < 11) {
                Console.WriteLine("Карта: " + k);
            } else {
                switch (k) {
                    case 11: 
                        Console.WriteLine("Карта: валет");
                        break;
                    case 12:
                        Console.WriteLine("Карта: дама");
                        break;
                    case 13:
                        Console.WriteLine("Карта: король");
                        break;
                    case 14:
                        Console.WriteLine("Карта: туз");
                        break;
                }
            }
        }
        Console.WriteLine("Нажмите любую клавишу для завершения программы");
        Console.ReadKey();
    }
}

