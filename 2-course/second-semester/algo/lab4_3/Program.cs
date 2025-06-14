using System;

class Program
{
    static void Main()
    {
        int[,] M = new int[5, 5];
        Random rand = new Random();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                M[i, j] = rand.Next(-5, 10);
            }
        }

        int min = M[0, 4];
        for (int i = 1; i < 5; i++)
        {
            int j = 4 - i;
            if (M[i, j] < min)
            {
                min = M[i, j];
            }
        }

        Console.WriteLine("Матрица M:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{M[i, j],5}");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"\nМинимальный элемент на побочной диагонали: {min}");
    }
}