using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int[] A = new int[10];

        for (int i = 0; i < 10; i++)
        {
            A[i] = rand.Next(-50, 100);
        }

        
        int? minEven = null;

        foreach (int num in A)
        {
            if (num > 0 && num % 2 == 0)
            {
                if (minEven == null || num < minEven)
                {
                    minEven = num;
                }
            }
        }

        Console.WriteLine("Массив A: " + string.Join(", ", A));
        if (minEven != null)
        {
            Console.WriteLine($"Наименьший чётный положительный элемент: {minEven}");
        }
        else
        {
            Console.WriteLine("Нет положительных чётных элементов в массиве.");
        }
    }
}
