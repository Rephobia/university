namespace lab3_3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите номер дня недели (1–7): ");
            int day = int.Parse(Console.ReadLine());

            if (day < 1 || day > 7)
            {
                Console.WriteLine("Ошибка: номер дня должен быть от 1 до 7.");
            }
            else if (day == 6 || day == 7)
            {
                Console.WriteLine("Это выходной день.");
            }
            else
            {
                Console.WriteLine("Это будний день.");
            }
        }
    }
}