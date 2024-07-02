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

        private int GetMaxIndex(int[] a, int i, int j, ref int sr, ref int obm)
        {
            if (i == j) { 
                return i;
            }

            int k = GetMaxIndex(a, i + 1, j, ref sr, ref obm);
            sr++;
            return (a[i] > a[k]) ? i : k;
        }

        public void SelectSortRecursive(int[] a, int n, int index, ref int sr, ref int obm)
        {
            if (index == n)
            {
                return;
            }

            int max = GetMaxIndex(a, index, n - 1, ref sr, ref obm);

            if (max != index)
            {
                swap(ref a[max], ref a[index]);
                obm++;
            }

            SelectSortRecursive(a, n, index + 1, ref sr, ref obm);
        }

        public void ShellSort(int[] a, ref int sr, ref int obm)
        {
            //расстояние между элементами, которые сравниваются
            var d = a.Length / 2;

            while (d >= 1)
            {
                for (var i = d; i < a.Length; i++)
                {
                    var j = i;

                    while ((j >= d) && (a[j - d] > a[j]))
                    {
                        sr++;
                        swap(ref a[j], ref a[j - d]);
                        obm++;
                        j = j - d;
                    }
                }
                sr++;
                d /= 2;
     
            }
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