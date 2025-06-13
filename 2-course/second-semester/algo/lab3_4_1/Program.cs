namespace lab3_4_1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());

            Console.Write("Введите значение V: ");
            double V = double.Parse(Console.ReadLine());

            double sum = 0;
            int n = 1;
            double an;

            do
            {
                an = (3.0 * n * x) / Factorial(n + 2);
                sum += an;
                n++;
            } while (sum <= V);

            Console.WriteLine($"Сумма превысила V на шаге № {n - 1}, сумма = {sum:F6}");
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