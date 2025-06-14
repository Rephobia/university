using System;
using System.Windows.Forms;

namespace lab5_1
{
    public partial class Form1 : Form
    {
        private string currentInput = "";
        private string expression = "";
        private string lastOperator = "";
        private double result = 0;

        public Form1()
        {
            InitializeComponent();
            AssignButtonHandlers();
        }

        private void AssignButtonHandlers()
        {
            // Цифры
            button1.Click += (s, e) => AppendDigit("0");
            button2.Click += (s, e) => AppendDigit("1");
            button3.Click += (s, e) => AppendDigit("2");
            button4.Click += (s, e) => AppendDigit("3");
            button5.Click += (s, e) => AppendDigit("4");
            button6.Click += (s, e) => AppendDigit("5");
            button7.Click += (s, e) => AppendDigit("6");
            button8.Click += (s, e) => AppendDigit("7");
            button9.Click += (s, e) => AppendDigit("8");
            button10.Click += (s, e) => AppendDigit("9");

            // Операции
            button12.Click += (s, e) => SetOperator("+");
            button13.Click += (s, e) => SetOperator("-");
            button14.Click += (s, e) => SetOperator("*");
            button15.Click += (s, e) => SetOperator("/");

            button11.Click += (s, e) => Backspace();
            button16.Click += (s, e) => CalculateResult();
        }

        private void AppendDigit(string digit)
        {
            currentInput += digit;
            expression += digit;
            textBox1.Text = expression;
        }

        private void SetOperator(string op)
        {
            if (double.TryParse(currentInput, out double parsed))
            {
                result = parsed;
                lastOperator = op;
                currentInput = "";
                expression += op;
                textBox1.Text = expression;
            }
        }

        private void CalculateResult()
        {
            if (double.TryParse(currentInput, out double secondOperand))
            {
                double finalResult = result;

                switch (lastOperator)
                {
                    case "+":
                        finalResult += secondOperand;
                        break;
                    case "-":
                        finalResult -= secondOperand;
                        break;
                    case "*":
                        finalResult *= secondOperand;
                        break;
                    case "/":
                        if (secondOperand != 0)
                            finalResult /= secondOperand;
                        else
                        {
                            MessageBox.Show("Деление на ноль!", "Ошибка");
                            return;
                        }
                        break;
                    default:
                        return;
                }

                expression += "=" + finalResult;
                textBox1.Text = expression;

                // Сброс для следующего выражения
                currentInput = finalResult.ToString();
                expression = "";
                lastOperator = "";
                result = finalResult;
            }
        }

        private void Backspace()
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
                expression = expression.Substring(0, expression.Length - 1);
                textBox1.Text = expression;
            }
        }
    }
}
