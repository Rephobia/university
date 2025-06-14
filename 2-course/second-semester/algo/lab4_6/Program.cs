using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random rand = new Random();

        int[] C = new int[17];
        for (int i = 0; i < C.Length; i++)
        {
            C[i] = rand.Next(-5, 5);
        }

        int[,] A = new int[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                A[i, j] = rand.Next(-5, 5);

        Console.WriteLine("Массив C[17]:");
        Console.WriteLine(string.Join(", ", C));

        Console.WriteLine("Матрица A[4,4]:");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
                Console.Write($"{A[i, j],4}");
            Console.WriteLine();
        }

        double z = C.Average();
        Console.WriteLine($"\nСреднее арифметическое z = {z:F2}");

        Console.Write("\nВведите значение y: ");
        int y = int.Parse(Console.ReadLine());

        List<int> allElements = new List<int>(C);
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                allElements.Add(A[i, j]);

        List<int> X = allElements
            .Where(xi => xi > z && xi < y)
            .OrderByDescending(xi => xi)
            .ToList();

        Console.WriteLine("\nМассив X (отсортирован по убыванию):");
        Console.WriteLine(string.Join(", ", X));
    }
}
