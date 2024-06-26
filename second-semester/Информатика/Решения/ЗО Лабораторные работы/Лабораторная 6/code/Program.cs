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

        return sum / data.Length;
    }

    static void Main(string[] args)
    {
        int inputSize = Convert.ToInt32(Console.ReadLine());
    }
}

