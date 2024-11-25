using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label7.Text = "";
            if (numericUpDown4.Value < numericUpDown5.Value)
            {
                label7.Text = "Макс значение не м.б. меньше мин значения!"; 
                return; 
            }

            int current = 0;
            int count = (Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(numericUpDown1.Value)) /
                Convert.ToInt32(numericUpDown3.Value) + 1;

                for (int n = Convert.ToInt32(numericUpDown1.Value); 
                    n <= Convert.ToInt32(numericUpDown2.Value);
                    n += Convert.ToInt32(numericUpDown3.Value))
                {
                    int[] vptr = new int[n];
                    Random rand = new Random();
                    for (int j = 0; j < n; j++)
                    {                 
                        vptr[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown4.Value));
                    }
                    if (checkBox1.Checked)
                    {
                        dataGridView1.ColumnCount = n + 1;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = "Исходный массив";
                        for (int j = 0; j < n; j++)
                        {
                            dataGridView1.Rows[i].Cells[j + 1].Value = vptr[j];
                        }
                        i++;
                    }
                    sort(vptr, n);
                    current += 1;
                    progressBar1.Value = 100 * current / count;
                }
            }

        private void sort(int[] p, int n)
        {
            int k = 0, sr = 0, obm = 0, m = 0;
            for (int j = 0; j < n; j++)
            {
                if (p[j] == 0) k++;
                else p[j - k] = p[j];
            }
            n -= k;
            sr += n;
            if (n == 0)
            {
                label7.Text = "В массиве одни нули"; return;
            }
            for (m = 0; m < n - 1; m++)
            {
                for (int j = m + 1; j < n; j++)
                {
                    if (p[m] > 0 && p[j] > 0 && p[m] < p[j])
                    {
                        swap(ref p[m], ref p[j]); obm++;
                    }
                    if (p[m] < 0 && p[j] < 0 && p[m] > p[j])
                    {
                        swap(ref p[m], ref p[j]); obm++;
                    }
                    sr += 6;
                }
            }
            if (checkBox1.Checked)
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = "Получен массив";
            for (int j = 0; j < n; j++)
                { dataGridView1.Rows[i].Cells[j + 1].Value = p[j]; }
                i++;
            }

            if (Convert.ToInt32(numericUpDown1.Value) == Convert.ToInt32(numericUpDown2.Value))
            {
                label8.Text = "Количество сравнений=" + Convert.ToString(sr) + " Количество обменов=" + Convert.ToString(obm);
            }
            if (checkBox2.Checked)
            {
                chart1.Series[0].Points.AddXY(n, sr);
                chart2.Series[0].Points.AddXY(n, obm);
            }
        }

        void swap(ref int x, ref int y)
        { int z = x; x = y; y = z; }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            i = 0;
            button1.Enabled = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        int n, m;

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            dataGridView4.Rows.Clear();
            dataGridView4.Columns.Clear();
            button3.Enabled = true;
            label15.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i, j, k, q;
            button3.Enabled = false;
            if (numericUpDown8.Value < numericUpDown9.Value)
            {
                label15.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }
            n = Convert.ToInt32(numericUpDown6.Value);
            m = Convert.ToInt32(numericUpDown6.Value);
            int[,] ptr = new int[m, n];

            Random rand = new Random();
            dataGridView2.AutoResizeColumns();
            dataGridView2.ColumnCount = n;
            for (i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();
                for (j = 0; j < m; j++)
                {
                    ptr[i, j] =
                    rand.Next(Convert.ToInt32(numericUpDown9.Value),
                    Convert.ToInt32(numericUpDown8.Value));
                    dataGridView2.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
            this.MakePersonalTicket(ptr);
            q = 0;
            k = 0;
            if (ptr[n - 1, m - 1] < 0) k++;
            for (q = 0; q < n - 1; q++)
            {
                if (ptr[q, m - 1] < 0)
                {
                    k++;

                    for (i = q; i < n - 1; i++)

                    {
                        for (j = 0; j < m; j++) ptr[i, j] = ptr[i + 1, j];
                    }
                    q--;
                }
                if (k + q + 1 == n) { break; }
            }
            if (k == n)
            {
                label15.Text = "В матрице удалены все строки";
                return;
            }
            if (k == 0)
            {
                label15.Text = "В матрице нет удаленных строк";
                return;
            }
            label15.Text = "В матрице удалено " + k + " строк(и)";
            for (j = 0; j < m; j++)
            {
                ptr[n - k, j] = 0;
                for (i = 0; i < n - k; i++)
                {
                    ptr[n - k, j] += ptr[i, j];
                }
            }
            dataGridView3.AutoResizeColumns();
            dataGridView3.ColumnCount = n;
            for (i = 0; i <= n - k; i++)
            {
                dataGridView3.Rows.Add();
                for (j = 0; j < m; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
        }

        /// <summary>
        /// 8. В матрице удалить первую и последнюю строки, а затем добавить строку
        /// из максимальных элементов соответствующих столбцов.
        /// </summary>
        private void MakePersonalTicket(int[,] matrix)
        {
            matrix = this.TrimFirstAndLastRow(matrix);
            matrix = this.AppendMaxRow(matrix);

            dataGridView4.AutoResizeColumns();
            dataGridView4.ColumnCount = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                dataGridView4.Rows.Add();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView4.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Удаляет первый и последний ряд в двумерном массиве
        /// </summary>
        private int[,] TrimFirstAndLastRow(int[,] matrix)
        {
            if (matrix.GetLength(0) < 2)
            {
                return new int[0,0];
            }
            int[,] result = new int[matrix.GetLength(0) - 2, matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i + 1, j];
                }
            }

            return result;
        }
        /// <summary>
        /// Добавляет ряд максимальных значений матрицы
        /// </summary>
        private int[,] AppendMaxRow(int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(0) + 1, matrix.GetLength(1)];

            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int row = 0;
                int maxValueInColumn = matrix[row, column];
                for (; row < matrix.GetLength(0); row++)
                {
                    result[row, column] = matrix[row, column];
                    maxValueInColumn = Math.Max(maxValueInColumn, matrix[row, column]);
                }
                result[row, column] = maxValueInColumn;
            }

            return result;
        }
    }
}
