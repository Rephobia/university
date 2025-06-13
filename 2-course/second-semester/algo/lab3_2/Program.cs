namespace lab3_2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Фунты\tКилограммы");
            Console.WriteLine("---------------------");

            for (int pounds = 1; pounds <= 10; pounds++)
            {
                double kilograms = pounds * 0.4;
                Console.WriteLine($"{pounds}\t{kilograms:F2}");
            }
        }
    }
}