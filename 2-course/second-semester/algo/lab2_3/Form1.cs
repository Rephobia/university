namespace lab2_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int score = 0;

            if (radioButton2.Checked) score++;
            if (radioButton4.Checked) score++;
            if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked) score += 1;

            label1.Text = $"Правильных ответов: {score} из 3";
        }
    }
}
