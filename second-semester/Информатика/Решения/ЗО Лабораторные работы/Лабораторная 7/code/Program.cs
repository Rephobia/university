using System;

internal class Program
{

    static double Average(int[,] matrix)
    {
        double sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        return sum / (matrix.GetLength(0) * matrix.GetLength(1));
    }

    static int GetMaxSumIndex(int[,] matrix)
    {
        int maxSumIndex = 0;
        int maxSum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int rowSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rowSum += matrix[i, j];
            }

            if (maxSum < rowSum)
            {
                maxSumIndex = i;
                maxSum = rowSum;
            }
        }

        return maxSumIndex;
    }

    static int[,] SwapLastRow(int[,] matrix)
    {
        int[,] result = matrix;

        int maxSumIndex = GetMaxSumIndex(matrix);
        int lastRowIndex = matrix.GetLength(0) - 1;

        int[] tmpLastRow = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(1); i++) 
        {
            tmpLastRow[i] = matrix[lastRowIndex, i];
            result[lastRowIndex, i] = result[maxSumIndex, i];
        }

        for (int i = 0; i < tmpLastRow.Length; i++)
        {
            result[maxSumIndex, i] = tmpLastRow[i];
        }

        return result;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число строк:");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число столбцов:");
        int columns = Convert.ToInt32(Console.ReadLine());

        int[,] inputMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine("Введите строку:");
            for (int j = 0; j < columns; j++)
            {
                inputMatrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

    
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(inputMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }


        Console.WriteLine(Average(inputMatrix));
        int[,] result = SwapLastRow(inputMatrix);
        Console.WriteLine("Результат");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(result[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

