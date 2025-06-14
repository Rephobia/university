class Program
{
    static void Main()
    {
        Random rand = new Random();

        double[] x = new double[10];
        double[] a = new double[10];
        double[] z = new double[10];

        for (int i = 0; i < 10; i++)
        {
            x[i] = rand.Next(1, 101);
            a[i] = rand.Next(1, 101);
        }

        for (int i = 0; i < 10; i++)
        {
            z[i] = Math.Sqrt((x[i] + a[i]) / 2.0);
        }

        // Вывод исходных и результирующего массива
        Console.WriteLine("Массив x: " + string.Join(", ", x));
        Console.WriteLine("Массив a: " + string.Join(", ", a));
        Console.WriteLine("Массив z (результат):");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"z[{i}] = {z[i]:F2}");
        }
    }
}