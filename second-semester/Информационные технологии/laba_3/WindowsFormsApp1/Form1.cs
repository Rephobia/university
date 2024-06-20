using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly String recursiveMode = "recursive";
        private readonly String cycleMode = "cycle";

        private String currentMode = "";

        public Form1()
        {
            this.currentMode = this.cycleMode;
            InitializeComponent();
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].BorderWidth = 3;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[0].LegendText = "Сравнения";
            chart1.Series[1].LegendText = "Обмены";
            chart2.Series[0].BorderWidth = 3;
            chart2.Series[0].Color = Color.Red;
            chart2.Series[1].BorderWidth = 3;
            chart2.Series[1].Color = Color.Blue;
            chart2.Series[0].LegendText = "Сравнения";
            chart2.Series[1].LegendText = "Обмены";
            chart3.Series[0].BorderWidth = 3;
            chart3.Series[0].Color = Color.Red;
            chart3.Series[1].BorderWidth = 3;
            chart3.Series[1].Color = Color.Blue;
            chart3.Series[0].LegendText = "Сравнения";
            chart3.Series[1].LegendText = "Обмены";
        }
        public void output_textBox(int[] out_a, int n) //вывод массива в textBox
        {
            for (int i = 0; i < n; i++)
            { textBox1.Text += out_a[i] + " "; }
            textBox1.Text += Environment.NewLine;
        }
        public void output_dataGridView(int count, int sr, int obm, int vid_sort) //вывод в таблицу кол-ва сравнений и обменов
        {
            dataGridView1.Rows [count].Cells [vid_sort].Value = sr;
            dataGridView2.Rows [count].Cells [vid_sort].Value = obm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "Размер";
            dataGridView1.Columns[1].HeaderText = "Выбор";
            dataGridView1.Columns[2].HeaderText = "Вставки";
            dataGridView1.Columns[3].HeaderText = "Пузырек";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "Размер";
            dataGridView2.Columns[1].HeaderText = "Выбор";
            dataGridView2.Columns[2].HeaderText = "Вставки";
            dataGridView2.Columns[3].HeaderText = "Пузырек";
            dataGridView1.ColumnCount = 4;
            dataGridView2.ColumnCount = 4;
            if (numericUpDown4.Value < numericUpDown5.Value)
            { label8.Text = "Макс значение не м.б. меньше мин значения!"; return; }
            int count = 0, n, sr = 0, obm = 0;
            ArraySort sort_select = new ArraySort();
            ArraySort sort_insert = new ArraySort();
            ArraySort sort_bubble = new ArraySort();
            for (n = Convert.ToInt32(numericUpDown1.Value);
                n <= Convert.ToInt32(numericUpDown2.Value);
                n += Convert.ToInt32(numericUpDown3.Value))
            {
                int[] base_a = new int[n];
                Random rand = new Random();
                for (int j = 0; j < n; j++)
                {
                    base_a[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value),
                    Convert.ToInt32(numericUpDown4.Value));
                }
                textBox1.Text += "Исходный массив " + Environment.NewLine;
                output_textBox(base_a, n);
                dataGridView1.Rows.Add();
                dataGridView1.Rows[count].Cells[0].Value = n;
                dataGridView2.Rows.Add();
                dataGridView2.Rows[count].Cells[0].Value = n;

                if (this.currentMode == this.cycleMode)
                {
                    this.ExecuteCycleMode(
                        base_a, 
                        sort_select,
                        sort_insert,
                        sort_bubble,
                        ref sr,
                        ref obm,
                        ref count,
                        ref n
                        );
                }
                else
                {
                    this.ExecuteRecursiveMode(
                        base_a,
                        sort_select,
                        ref sr,
                        ref obm,
                        ref count,
                        ref n
                        );
                }
            }
        }

        private void ExecuteCycleMode(
            int[] base_a, 
            ArraySort sort_select,
            ArraySort sort_insert,
            ArraySort sort_bubble,
            ref int sr,
            ref int obm,
            ref int count,
            ref int n
            )
        {
            sort_select.a = (int[])base_a.Clone();
            sr = 0; obm = 0;
            sort_select.SelectSort(sort_select.a, ref sr, ref obm);
            textBox1.Text += "Сортировка выбором " + Environment.NewLine;
            output_textBox(sort_select.a, n);
            output_dataGridView(count, sr, obm, 1);
            chart1.Series[0].Points.AddXY(n, sr);
            chart1.Series[1].Points.AddXY(n, obm);
            sort_insert.a = (int[])base_a.Clone();
            sr = 0; obm = 0;
            sort_insert.InsertSort(sort_insert.a, ref sr, ref obm);
            textBox1.Text += "Сортировка вставками " + Environment.NewLine;
            output_textBox(sort_insert.a, n);
            output_dataGridView(count, sr, obm, 2);
            chart2.Series[0].Points.AddXY(n, sr);
            chart2.Series[1].Points.AddXY(n, obm);
            sort_bubble.a = (int[])base_a.Clone();
            sr = 0; obm = 0;
            sort_bubble.BubbleSort(sort_bubble.a, ref sr, ref obm);
            textBox1.Text += "Сортировка пузырьком " + Environment.NewLine;
            output_textBox(sort_bubble.a, n);
            output_dataGridView(count, sr, obm, 3);
            chart3.Series[0].Points.AddXY(n, sr);
            chart3.Series[1].Points.AddXY(n, obm);
            count++;
        }
        private void ExecuteRecursiveMode(
            int[] base_a,
            ArraySort sort_select,
            ref int sr,
            ref int obm,
            ref int count,
            ref int n)
        {
            sort_select.a = (int[])base_a.Clone();
            sr = 0; obm = 0;
            sort_select.SelectSortRecursive(sort_select.a, sort_select.a.Length, 0);
            textBox1.Text += "Сортировка выбором " + Environment.NewLine;
            output_textBox(sort_select.a, n);
            output_dataGridView(count, sr, obm, 1);
            chart1.Series[0].Points.AddXY(n, sr);
            chart1.Series[1].Points.AddXY(n, obm);       
            count++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            textBox1.Text = "";
            button1.Enabled = true;
            цикламиToolStripMenuItem.Enabled = true;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart3.Series[1].Points.Clear();
        }
        private void сохранитьВсёГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранитьГрафикСортировкиВставкамиToolStripMenuItem_Click(sender, e);
            сохранитьГрафикСортировкиВыборомToolStripMenuItem_Click(sender, e);
            сохранитьГрафикСортировкиПузырькомToolStripMenuItem_Click(sender, e);
        }
        private void сохранитьГрафикСортировкиВставкамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr1 = new SaveFileDialog())
            {
                saveGr1.Title = "Сохранить график как ...";
                saveGr1.Filter = "*.jpg|*.jpg";
                saveGr1.AddExtension = true;
                saveGr1.FileName = "Insert";
                if (saveGr1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart2.SaveImage(saveGr1.FileName,
                    System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикСортировкиВыборомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr = new SaveFileDialog())
            {
                saveGr.Title = "Сохранить график как ...";
                saveGr.Filter = "*.jpg|*.jpg"; saveGr.AddExtension = true;
                saveGr.FileName = "Select";
                if (saveGr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    chart1.SaveImage(saveGr.FileName,
                    System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void сохранитьГрафикСортировкиПузырькомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveGr2 = new SaveFileDialog())
            {
                saveGr2.Title = "Сохранить график как ...";
                saveGr2.Filter = "*.jpg|*.jpg";
                saveGr2.AddExtension = true;
                saveGr2.FileName = "Bubble";
                if (saveGr2.ShowDialog() ==
                System.Windows.Forms.DialogResult.OK)
                {
                    chart3.SaveImage(saveGr2.FileName,
                    System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }
            }
        }
        private void цикламиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            цикламиToolStripMenuItem.Enabled = false;
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 help = new Form2();
            help.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void рекурсивнымиФункциямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.currentMode = this.recursiveMode;
        }

        private void цикламиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.currentMode = this.cycleMode;
        }
    }
}
