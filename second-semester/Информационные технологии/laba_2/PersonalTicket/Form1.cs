using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalTicket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            richTextBox1.KeyUp += TextBox1_KeyUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ContextMenu contextMenu1;
            contextMenu1 = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem menuItem1;
            menuItem1 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem2;
            menuItem2 = new System.Windows.Forms.MenuItem();
            System.Windows.Forms.MenuItem menuItem3;
            menuItem3 = new System.Windows.Forms.MenuItem();
            contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
menuItem1, menuItem2, menuItem3 });
            menuItem1.Index = 0;
            menuItem1.Text = "Открыть";
            menuItem2.Index = 1;
            menuItem2.Text = "Сохранить";
            menuItem3.Index = 2;
            menuItem3.Text = "Сохранить как";
            richTextBox1.ContextMenu = contextMenu1;
            menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
        }
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = openFileDialog1.FileName;
                richTextBox1.LoadFile(MyFName);
            }
        }
        string MyFName = "";
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (MyFName != "")
            {
                richTextBox1.SaveFile(MyFName);
            }
            else
            {
                saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MyFName = saveFileDialog1.FileName;
                    richTextBox1.SaveFile(MyFName);
                }
            }
        }
        private void menuItem3_Click(object sender, System.EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовые файлы (*.rtf; *.txt; *.dat) | *.rtf; *.txt; *.dat";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MyFName = saveFileDialog1.FileName;
                richTextBox1.SaveFile(MyFName);
            }
        }

        private bool isEditor = true;
        int minWordLength = 0;
        private int[] positions = new int[0];
        private int positionOfPositions = -1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isEditor)
            {
                label1.Text = "Поиск";
                richTextBox1.ReadOnly = true;
                this.isEditor = false;
                this.FillPositions();
            } else
            {
                label1.Text = "Ввод текста";
                richTextBox1.ReadOnly = false;
                this.isEditor = true;
            }
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.isEditor == false)
            {
                if (this.positionOfPositions != -1)
                {
                    richTextBox1.SelectionStart = this.positions[positionOfPositions++];
                    richTextBox1.SelectionLength = this.minWordLength;
                    richTextBox1.SelectionBackColor = Color.Green;
                    if (this.positionOfPositions == this.positions.Length)
                    {
                        this.positionOfPositions = 0;
                    }
                    label2.Text = "Количество символов в минимальном слове: " + this.minWordLength;
                }
                else
                {
                    label2.Text = "Текст пустой";
                }
                
            }

        }

        int FindMinWordLength(String text)
        {
            int result = text.Length;

            foreach (var word in text.Split(' '))
            {
                if (word.Length < result)
                {
                    result = word.Length;
                }
            }
            return result;
        }

        void FillPositions()
        {
            this.minWordLength = this.FindMinWordLength(richTextBox1.Text);
            
            var words = richTextBox1.Text.Split(' ');
            var minLengthWords = words.Where(w => w.Length == this.minWordLength).ToArray();
            var index = 0;
            if (minLengthWords.Length > 0)
            {
                this.positionOfPositions = 0;
                Array.Resize(ref this.positions, minLengthWords.Length);
                foreach (var word in minLengthWords)
                {
                    string pattern = @"\b" + Regex.Escape(word) + @"\b";
                    Regex regExp = new Regex(pattern);
                    var matches = regExp.Matches(richTextBox1.Text);
                    foreach (Match match in matches)
                    {
                        this.positions[index++] = match.Index;
                    }
                }
            }
        }
    }

 
}
