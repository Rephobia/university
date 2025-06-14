using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        LinkedList<double> list = new LinkedList<double>();

        Console.WriteLine("Введите числа (разделяйте пробелами, Enter — завершить):");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                break;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (double.TryParse(part, out double value))
                    list.AddFirst(value);
                else
                    Console.WriteLine($"'{part}' — не число");
            }
        }

        Console.WriteLine("Список: " + GetListString(list));

        Console.WriteLine("Список пуст? " + (IsEmpty(list) ? "Да" : "Нет"));

        if (!IsEmpty(list))
        {
            Console.WriteLine("Среднее арифметическое: " + Average(list));

            SwapFirstLast(list);
            Console.WriteLine("После обмена первого и последнего элементов:");
            Console.WriteLine("Список: " + GetListString(list));

            Console.WriteLine("Список упорядочен? " + (IsSorted(list) ? "Да" : "Нет"));

            if (list.Count >= 2)
                Console.WriteLine("Сумма последних двух элементов: " + SumLastTwoElements(list));
            else
                Console.WriteLine("Недостаточно элементов для вычисления суммы двух последних.");
        }

        // Демонстрация операций со списками
        LinkedList<int> L1 = new LinkedList<int>(new[] { 1, 2, 3, 4 });
        LinkedList<int> L2 = new LinkedList<int>(new[] { 3, 4, 5, 6 });

        Console.WriteLine("Объединение: " + GetListString(Union(L1, L2)));
        Console.WriteLine("Пересечение: " + GetListString(Intersection(L1, L2)));
        Console.WriteLine("Разность L1 - L2: " + GetListString(Difference(L1, L2)));
        Console.WriteLine("Симметрическая разность: " + GetListString(SymmetricDifference(L1, L2)));

        LinkedList<double> sorted1 = new LinkedList<double>(new[] { 1.1, 3.3, 5.5 });
        LinkedList<double> sorted2 = new LinkedList<double>(new[] { 2.2, 4.4, 6.6 });
        Console.WriteLine("Слияние отсортированных: " + GetListString(MergeSorted(sorted1, sorted2)));
    }

    static string GetListString<T>(LinkedList<T> list)
    {
        return string.Join(", ", list);
    }

    static bool IsEmpty<T>(LinkedList<T> list) => list.Count == 0;

    static double Average(LinkedList<double> list)
    {
        if (list.Count == 0) return 0;
        double sum = 0;
        foreach (var item in list)
            sum += item;
        return sum / list.Count;
    }

    static void SwapFirstLast<T>(LinkedList<T> list)
    {
        if (list.Count < 2) return;

        var first = list.First;
        var last = list.Last;

        T temp = first.Value;
        first.Value = last.Value;
        last.Value = temp;
    }

    static bool IsSorted(LinkedList<double> list)
    {
        if (list.Count <= 1) return true;

        var current = list.First;
        while (current.Next != null)
        {
            if (current.Value > current.Next.Value)
                return false;
            current = current.Next;
        }

        return true;
    }

    static int SumLastTwoElements(LinkedList<double> list)
    {
        var last = list.Last.Value;
        var secondLast = list.Last.Previous.Value;
        return (int)last + (int)secondLast;
    }

    static LinkedList<int> Union(LinkedList<int> L1, LinkedList<int> L2)
    {
        var set = new HashSet<int>(L1);
        foreach (var item in L2)
            set.Add(item);
        return new LinkedList<int>(set);
    }

    static LinkedList<int> Intersection(LinkedList<int> L1, LinkedList<int> L2)
    {
        var set1 = new HashSet<int>(L1);
        var result = new LinkedList<int>();
        foreach (var item in L2)
            if (set1.Contains(item))
                result.AddLast(item);
        return new LinkedList<int>(result.Distinct());
    }

    static LinkedList<int> Difference(LinkedList<int> L1, LinkedList<int> L2)
    {
        var set2 = new HashSet<int>(L2);
        var result = new LinkedList<int>();
        foreach (var item in L1)
            if (!set2.Contains(item))
                result.AddLast(item);
        return new LinkedList<int>(result.Distinct());
    }

    static LinkedList<int> SymmetricDifference(LinkedList<int> L1, LinkedList<int> L2)
    {
        var set1 = new HashSet<int>(L1);
        var set2 = new HashSet<int>(L2);
        var result = new LinkedList<int>();

        foreach (var item in set1)
            if (!set2.Contains(item))
                result.AddLast(item);

        foreach (var item in set2)
            if (!set1.Contains(item))
                result.AddLast(item);

        return result;
    }

    static LinkedList<double> MergeSorted(LinkedList<double> L1, LinkedList<double> L2)
    {
        var merged = new List<double>(L1);
        merged.AddRange(L2);
        merged.Sort();
        return new LinkedList<double>(merged);
    }
}


