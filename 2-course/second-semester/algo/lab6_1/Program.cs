using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int[] array = new int[8];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rnd.Next(1, 21);
        }

        Console.WriteLine("Исходный массив:");
        PrintArray(array);

        int[] arrSelection = (int[])array.Clone();
        int[] arrBubble = (int[])array.Clone();
        int[] arrInsertion = (int[])array.Clone();

        Console.WriteLine("\nСортировка методом выбора:");
        SortSelection(arrSelection);

        Console.WriteLine("\nСортировка методом пузырька:");
        SortBubble(arrBubble);

        Console.WriteLine("\nСортировка методом вставки:");
        SortInsertion(arrInsertion);
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(", ", arr));
    }

    static void SortSelection(int[] arr)
    {
        int n = arr.Length;
        int comparisons = 0;
        int assignments = 0;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                comparisons++;
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
                assignments += 3;
            }
        }

        PrintArray(arr);
        Console.WriteLine($"Сравнений: {comparisons}, присвоений: {assignments}");
    }

    static void SortBubble(int[] arr)
    {
        int n = arr.Length;
        int comparisons = 0;
        int assignments = 0;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                comparisons++;
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    assignments += 3;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }

        PrintArray(arr);
        Console.WriteLine($"Сравнений: {comparisons}, присвоений: {assignments}");
    }

    static void SortInsertion(int[] arr)
    {
        int n = arr.Length;
        int comparisons = 0;
        int assignments = 0;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            assignments++;
            int j = i - 1;

            while (j >= 0)
            {
                comparisons++;
                if (arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    assignments++;
                    j--;
                }
                else
                {
                    break;
                }
            }
            arr[j + 1] = key;
            assignments++;
        }

        PrintArray(arr);
        Console.WriteLine($"Сравнений: {comparisons}, присвоений: {assignments}");
    }
}
