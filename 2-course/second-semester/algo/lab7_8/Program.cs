using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int size = 10;
        int[] arr = new int[size];

        Console.WriteLine("Сгенерированный массив:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = rnd.Next(1, 100);
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        int min = FindMin(arr, 0, arr[0]);
        Console.WriteLine($"Минимальный элемент массива: {min}");
    }

    static int FindMin(int[] arr, int index, int currentMin)
    {
        if (index == arr.Length)
            return currentMin;

        if (arr[index] < currentMin)
            currentMin = arr[index];

        return FindMin(arr, index + 1, currentMin);
    }
}

