using System;

class Program
{
    static void Main()
    {
        int[,] T = new int[5, 5];
        Random rand = new Random();

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                T[i, j] = rand.Next(-5, 5);

    

        int max = int.MinValue;
        int maxCol = -1;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5 - 1 - i; j++)
            {
                if (T[i, j] > max)
                {
                    max = T[i, j];
                    maxCol = j;
                }
            }
        }

        Console.WriteLine("Исходная матрица:");
        PrintMatrix(T);

        Console.WriteLine($"Максимальный элемент выше побочной диагонали: {max}");

        if (maxCol != -1)
        {
            for (int i = 0; i < 5; i++)
                T[i, maxCol] = 0;
        }

        Console.WriteLine("Матрица после обнуления столбца:");
        PrintMatrix(T);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
                Console.Write($"{matrix[i, j],5}");
            Console.WriteLine();
        }
    }
}
