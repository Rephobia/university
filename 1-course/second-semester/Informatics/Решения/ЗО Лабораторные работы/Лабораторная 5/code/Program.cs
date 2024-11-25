using System;

class Program
{
    static void Main(string[] args)
    {
        double e = 1E-5;
        double g = 1E+5;
        int n = 1;
        double u;
        double denominator = (98 + 2 * n);
        bool isConvergent;
        bool isNotConvergent;
        double sum = 0;
        do
        {
            u = Math.Abs(Factorial(3 * n - 2) / denominator);
            denominator *= (98 + 2 * n);
            sum += u;

            Console.WriteLine(
                "Номер итерации: " + n + 
                ", значение члена ряда: " + u + 
                ", частичная сумма: " + sum
            );

            n++;
            isConvergent = u > e;
            isNotConvergent = u < g;
        } while (isConvergent && isNotConvergent);

        if (isConvergent)
        {
            Console.WriteLine("Ряд предположительно сходится");
        }
        if (isNotConvergent)
        {
            Console.WriteLine("Ряд не сходится");
        }
        Console.ReadKey();
    }

    static int Factorial(int n)
    {
        int result = 1;
        for (int i = n; i > 0; i--)
        {
            result *= i;
        }
        return result;
    }
}
