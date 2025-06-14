using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int[] array = new int[10];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(1, 100); 
        }

        Console.WriteLine("Массив: " + string.Join(", ", array));

        int minIndex = FindMinIndex(array, 0, array.Length - 1);
        Console.WriteLine($"Минимальный элемент: {array[minIndex]} на индексе {minIndex}");
    }

    static int FindMinIndex(int[] array, int start, int end)
    {
        if (start == end)
            return start;

        int minRestIndex = FindMinIndex(array, start + 1, end);
        return array[start] < array[minRestIndex] ? start : minRestIndex;
    }
}
