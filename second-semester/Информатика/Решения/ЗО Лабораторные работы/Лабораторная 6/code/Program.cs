using System;

internal class Program
{
    static double Average(int[] data)
    {
        int sum = 0;
        for (int i  = 0; i < data.Length; i++)
        {
            sum += data[i];
        }

        return (double) sum / (double) data.Length;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер массива:");
        int inputSize = Convert.ToInt32(Console.ReadLine());
        int[] inputData = new int[inputSize];

        Console.WriteLine("Введите элементы массива:");

        for (int i = 0; i < inputSize; i++)
        {
            inputData[i] = Convert.ToInt32(Console.ReadLine());
        }

        if (inputData.Length > 0)
        {
            int max = inputData[0];
            int maxIndex = 0;

            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] > max)
                {
                    max = inputData[i];
                    maxIndex = i;
                }
            }

            int[] result = new int[maxIndex + 1];

            for (int j = 0; j < result.Length; j++)
            {
                result[j] = inputData[j];
            }

            double avgInputData = Average(inputData);
            double avgResult = Average(result);

            Console.WriteLine("Исходный массив: " + String.Join(", ", inputData) + " Среднее арифметическое: " + avgInputData);
            Console.WriteLine("Сформированный массив: " + String.Join(", ", result) + " Среднее арифметическое: " + avgResult);
        }
        Console.ReadKey();
    }
}

