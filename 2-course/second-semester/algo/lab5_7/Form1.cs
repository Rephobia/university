using System;
using System.IO;
using System.Windows.Forms;

namespace lab5_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("��� ������ ��� ����������.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "��������� ���������� ����";
                saveFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                        MessageBox.Show("���� ������� �������!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("������ ��� ���������� �����:\n" + ex.Message);
                    }
                }
            }
        }

        private void OpenFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "������� ��������� ����";
                openFileDialog.Filter = "��������� ����� (*.txt)|*.txt|��� ����� (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(openFileDialog.FileName);
                        richTextBox1.Lines = lines;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("������ ��� ������ �����:\n" + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.OpenFile();
        }
    }
}
