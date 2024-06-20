using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ArraySort
    {
        public ArraySort() //конструктор
        {
        }
        public int[] a;
        private static void swap(ref int x, ref int y)
        {
            int temp = x; x = y; y = temp;
        }
        public void SelectSort(int[] a, ref int sr, ref int obm)
        {
            int max;
            int length = a.Length;
            for (int i = 0; i < length - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < length; j++)
                {
                    sr++;
                    if (a[j] > a[max])
                    {
                        max = j;
                    }
                }
                sr++;
                if (max != i)
                {
                    swap(ref a[i], ref a[max]);
                    obm++;
                }
            }
        }

        private int GetMaxIndex(int[] a, int i, int j)
        {
            if (i == j) { 
                return i;
            }

            int k = GetMaxIndex(a, i + 1, j);

            return (a[i] > a[k]) ? i : k;
        }

        public void SelectSortRecursive(int[] a, int n, int index)
        {
            if (index == n)
            {
                return;
            }

            int max = GetMaxIndex(a, index, n - 1);

            if (max != index)
            {
                swap(ref a[max], ref a[index]);
            }

            SelectSortRecursive(a, n, index + 1);
        }

        public void InsertSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int cur = a[i];
                int j = i;
                while (j > 0 && cur > a[j - 1])
                {
                    sr++;
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = cur;
            }
            sr++;
        }
        public void BubbleSort(int[] a, ref int sr, ref int obm)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    sr++;
                    if (a[j] < a[j + 1])
                    {
                        swap(ref a[j], ref a[j + 1]);
                        obm++;
                    }
                }
            }
        }
    }
}