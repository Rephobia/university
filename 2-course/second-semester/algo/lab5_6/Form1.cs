using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab5_6
{
    public partial class Form1 : Form
    {
        private List<string> originalItems = new List<string>();
        private List<string> currentItems = new List<string>();

        public Form1()
        {
            InitializeComponent();

            listBox1.ForeColor = System.Drawing.Color.DarkBlue;
            listBox1.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;

            originalItems = new List<string>(lines);
            currentItems = new List<string>(lines);

            UpdateListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < currentItems.Count)
            {
                currentItems.RemoveAt(selectedIndex);
                UpdateListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentItems = new List<string>(originalItems);
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (var item in currentItems)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
