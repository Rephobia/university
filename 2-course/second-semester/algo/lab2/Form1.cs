namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double A, B, C;

            if (!double.TryParse(textBox1.Text, out A) ||
                !double.TryParse(textBox2.Text, out B) ||
                !double.TryParse(textBox3.Text, out C))
            {
                resultLabel.Text = "������: ������� ���������� �����.";
                return;
            }

            if (A == 0)
            {
                resultLabel.Text = "������: A �� ������ ���� ����� 0.";
                return;
            }

            double D = B * B - 4 * A * C;

            if (D > 0)
            {
                double x1 = (-B + Math.Sqrt(D)) / (2 * A);
                double x2 = (-B - Math.Sqrt(D)) / (2 * A);
                resultLabel.Text = $"��� �����: x1 = {x1:F2}, x2 = {x2:F2}";
            }
            else if (D == 0)
            {
                double x = -B / (2 * A);
                resultLabel.Text = $"���� ������: x = {x:F2}";
            }
            else
            {
                resultLabel.Text = "�������������� ������ ���.";
            }
        }
    }
}
