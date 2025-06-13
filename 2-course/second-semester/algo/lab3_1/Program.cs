namespace lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double A = -7;
            double B = 7;
            double H = 0.5;

            Console.WriteLine(" X\t|  Y");
            Console.WriteLine("-------------------");

            for (double x = A; x <= B; x += H)
            {
                double y = Math.Abs(x * x + 5 * x - 6);
                Console.WriteLine($"{x:F2}\t|  {y:F2}");
            }
        }
    }
}