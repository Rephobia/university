namespace lab3_4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите эпсилон: ");
            double eps = double.Parse(Console.ReadLine());

            double sum = 0;
            int n = 1;
            double an = 1; // чтобы зайти в цикл хотя бы раз

            while (Math.Abs(an) >= eps)
            {
                an = (3.0 * n * x) / Factorial(n + 2);
                sum += an;
                n++;
            }

            Console.WriteLine($"Сумма ряда: {sum:F6}");
        }

        static double Factorial(int num)
        {
            double result = 1;
            for (int i = 2; i <= num; i++)
                result *= i;
            return result;
        }
    }
}