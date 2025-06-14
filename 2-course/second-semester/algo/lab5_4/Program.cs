using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();

        Console.WriteLine("Введите числа для добавления (разделяйте пробелами):");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                stack.Push(number);
                queue.Enqueue(number);
            }
            else
            {
                Console.WriteLine($"'{part}' — не число");
            }
        }

        Console.WriteLine("\nСодержимое стека (LIFO):");
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\nСодержимое очереди (FIFO):");
        foreach (var item in queue)
        {
            Console.Write(item + " ");
        }

        if (stack.Count > 0)
        {
            Console.WriteLine($"\n\nВерхний элемент стека: {stack.Peek()}");
            Console.WriteLine($"Извлечён из стека: {stack.Pop()}");
        }

        if (queue.Count > 0)
        {
            Console.WriteLine($"\nПервый элемент очереди: {queue.Peek()}");
            Console.WriteLine($"Извлечён из очереди: {queue.Dequeue()}");
        }

        Console.WriteLine("\nОставшееся содержимое стека:");
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\nОставшееся содержимое очереди:");
        foreach (var item in queue)
        {
            Console.Write(item + " ");
        }
    }
}
