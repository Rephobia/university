using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace lab5_8
{
    public partial class Form1 : Form
    {
        private string filePath = Path.Combine(Application.StartupPath, "temp.txt");

        public Form1()
        {
            InitializeComponent();

            listView1.View = View.List;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);

            imageList.Images.Add(SystemIcons.Information);

            listView1.SmallImageList = imageList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var item in listBox1.Items)
                {
                    lines.Add(item.ToString());
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    if (lines.Count > 0)
                    {
                        writer.WriteLine(lines[0]);
                        writer.WriteLine("Привет!");
                        for (int i = 1; i < lines.Count; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                    }
                }

                List<string> fileLines = new List<string>(File.ReadAllLines(filePath));

                fileLines.Sort();

                int index = fileLines.BinarySearch("Привет!");

                if (index >= 0)
                {
                    fileLines[index] = "Привет, Коля!";

                    MessageBox.Show("Ура, добавили!");
                }

                listView1.Items.Clear();
                foreach (string line in fileLines)
                {
                    ListViewItem lvi = new ListViewItem(line, 0);
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
