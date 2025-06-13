namespace lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первое число: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите третье число: ");
            double c = Convert.ToDouble(Console.ReadLine());

            double max = a;

            if (b > max)
                max = b;

            if (c > max)
                max = c;

            Console.WriteLine($"Максимальное число: {max}");
        }
    }
}
