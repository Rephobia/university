using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] array = new int[10];

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(0, 100);
            Console.Write(array[i] + " ");
        }

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("\nОтсортированный массив (метод Хоара):");
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int pivot = arr[(left + right) / 2];
        int index = Partition(arr, left, right, pivot);

        QuickSort(arr, left, index - 1);
        QuickSort(arr, index, right);
    }

    static int Partition(int[] arr, int left, int right, int pivot)
    {
        while (left <= right)
        {
            while (arr[left] < pivot) left++;
            while (arr[right] > pivot) right--;

            if (left <= right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++;
                right--;
            }
        }
        return left;
    }
}
