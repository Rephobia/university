using System;

class Program
{
    static void Main()
    {
        int totalWhite = 10;
        int totalBlack = 5;
        int selectTotal = 7;
        int selectBlack = 3;
        int selectWhite = selectTotal - selectBlack;

        int blackWays = Combination(totalBlack, selectBlack);
        int whiteWays = Combination(totalWhite, selectWhite);

        int totalWays = blackWays * whiteWays;

        Console.WriteLine($"Число способов выбрать {selectTotal} шаров с {selectBlack} черными: {totalWays}");
    }

    static int Combination(int n, int k)
    {
        if (k == 0 || k == n)
            return 1;
        if (k > n)
            return 0;
        return Combination(n - 1, k - 1) + Combination(n - 1, k);
    }
}
