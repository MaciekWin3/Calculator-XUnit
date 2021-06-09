using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorXUnit.Backend;

namespace CalculatorXUnit.Frontend
{
    public partial class Form1 : Form
    {
        private string sign;
        bool startNewNumber = true;
        private decimal num1;
        private decimal num2;
        bool negative = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NumberBt_Click("1");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberBt_Click("2");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NumberBt_Click("3");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            NumberBt_Click("4");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            NumberBt_Click("5");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            NumberBt_Click("6");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            NumberBt_Click("7");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            NumberBt_Click("8");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            NumberBt_Click("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            NumberBt_Click("0");

        }

        private void NumberBt_Click(string number)
        {
            if (startNewNumber == false)
            {
                textBox1.Text += number;
            }
            else
            {
                textBox1.Text = number;
                startNewNumber = false;
            }
        }

        private void NumberOperation(string sign)
        {
            try
            {
                num1 = Decimal.Parse(textBox1.Text);
            }
            catch(Exception e)
            {
                num1 = 0;
            }
            
            label1.Text = textBox1.Text;
            label1.Text += sign;
            this.sign = sign;
            startNewNumber = true;
            negative = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            NumberOperation("+");
            textBox1.Text = String.Empty;
        }

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            NumberOperation("-");
            textBox1.Text = String.Empty;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            NumberOperation("*");
            textBox1.Text = String.Empty;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            NumberOperation("/");
            textBox1.Text = String.Empty;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            try
            {
                decimal result = 0;
                Calculator calculator = new Calculator();
                num2 = Decimal.Parse(textBox1.Text);
                label1.Text = String.Empty;
                switch (sign)
                {
                    case "+":
                        result = calculator.Add(num1, num2);
                        break;
                    case "-":
                        result = calculator.Subtract(num1, num2);
                        break;
                    case "*":
                        result = calculator.Multiply(num1, num2);
                        break;
                    case "/":
                        result = calculator.Divide(num1, num2);
                        break;
                }

                textBox1.Text = result.ToString();                
                sign = String.Empty;
                startNewNumber = true;
                negative = false;
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label3.Text = "";
        }

        private void buttonClearE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            num1 = 0;
            num2 = 0;
            label1.Text = "";
            label3.Text = "";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            if (negative == false)
            {
                textBox1.Text = "-" + textBox1.Text;
                negative = true;
            }
            else
            {
                textBox1.Text = textBox1.Text.Substring(1, textBox1.Text.Length - 1);
                negative = false;
            }
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            NumberBt_Click(",");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();
            decimal numberToConvert;

            try
            {
                numberToConvert = Decimal.Parse(textBox1.Text);
            }
            catch
            {
                numberToConvert = 0;
            }

            label3.Text = textBox1.Text +" in binary = " + calculator.RoundAndConvertToBinary(numberToConvert);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator();

            decimal numberToRound = Decimal.Parse(textBox1.Text);

            int roundedNumber = calculator.Round(numberToRound);

            textBox1.Text = roundedNumber.ToString();

        }
    }
}
