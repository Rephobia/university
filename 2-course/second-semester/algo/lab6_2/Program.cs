using System;

class Program
{
    static void Main()
    {
        int[] array = new int[10];
        Random rnd = new Random();

        for (int i = 0; i < array.Length; i++)
            array[i] = rnd.Next(1, 51);

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        Console.WriteLine("\nСортировка методом выбора элементов на нечётных индексах:\n");
        SelectionSortOddPositions(array);
    }

    static void SelectionSortOddPositions(int[] arr)
    {
        int comparisons = 0;
        int assignments = 0;

        int n = arr.Length;

        int oddCount = (n % 2 == 0) ? n / 2 : n / 2 + 1;

        for (int i = 1; i < n; i += 2)
        {
            int minIndex = i;

            for (int j = i + 2; j < n; j += 2)
            {
                comparisons++;
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }

            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
                assignments += 3;
            }

            Console.WriteLine($"Шаг {((i + 1) / 2)}: выбрали минимум на позиции {minIndex} и поменяли с позицией {i}");
            PrintArray(arr);
            Console.WriteLine($"Сравнения: {comparisons}, присвоения: {assignments}\n");
        }

        Console.WriteLine("Итоговый массив после сортировки нечётных элементов:");
        PrintArray(arr);
        Console.WriteLine($"Всего сравнений: {comparisons}, присвоений: {assignments}");
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }
}
