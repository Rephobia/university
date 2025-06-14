using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();

        int[] arr1 = new int[5];
        int[] arr2 = new int[5];

        for (int i = 0; i < 5; i++)
        {
            arr1[i] = rand.Next(1, 50);
            arr2[i] = rand.Next(1, 50);
        }

        Console.WriteLine("Случайный первый массив:");
        PrintArray(arr1);
        Console.WriteLine("Случайный второй массив:");
        PrintArray(arr2);

        int[] merged = new int[arr1.Length + arr2.Length];
        MergeRecursive(arr1, 0, arr2, 0, merged, 0);

        Console.WriteLine("\nСлитый массив:");
        PrintArray(merged);
    }

    static void MergeRecursive(int[] arr1, int i, int[] arr2, int j, int[] merged, int k)
    {
        if (i == arr1.Length && j == arr2.Length)
            return;

        if (i == arr1.Length)
        {
            merged[k] = arr2[j];
            MergeRecursive(arr1, i, arr2, j + 1, merged, k + 1);
        }
        else if (j == arr2.Length)
        {
            merged[k] = arr1[i];
            MergeRecursive(arr1, i + 1, arr2, j, merged, k + 1);
        }
        else if (arr1[i] < arr2[j])
        {
            merged[k] = arr1[i];
            MergeRecursive(arr1, i + 1, arr2, j, merged, k + 1);
        }
        else
        {
            merged[k] = arr2[j];
            MergeRecursive(arr1, i, arr2, j + 1, merged, k + 1);
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
            Console.Write(item + " ");
        Console.WriteLine();
    }
}

