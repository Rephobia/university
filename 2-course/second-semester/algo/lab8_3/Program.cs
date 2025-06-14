using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] array = new int[10];

        for (int i = 0; i < array.Length; i++)
            array[i] = rand.Next(1, 100);

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        int[] sorted = MergeSort(array);

        Console.WriteLine("Отсортированный массив:");
        PrintArray(sorted);
    }

    static int[] MergeSort(int[] array)
    {
        if (array.Length <= 1)
            return array;

        int mid = array.Length / 2;

        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];
        Array.Copy(array, 0, left, 0, mid);
        Array.Copy(array, mid, right, 0, array.Length - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, l = 0, r = 0;

        while (l < left.Length && r < right.Length)
        {
            if (left[l] < right[r])
                result[i++] = left[l++];
            else
                result[i++] = right[r++];
        }

        while (l < left.Length)
            result[i++] = left[l++];

        while (r < right.Length)
            result[i++] = right[r++];

        return result;
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}
