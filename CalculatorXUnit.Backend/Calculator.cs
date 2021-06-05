using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorXUnit.Backend
{
    public class Calculator
    {
        decimal result;

        public decimal Add(decimal a, decimal b)
        {
            return a + b;
        }

        public decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        public decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }

        public decimal Divide(decimal a, decimal b)
        {
            if(b != 0)
            {
                return a / b;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        public string RoundAndConvertToBinary(decimal a)
        {
            int roundedNumber = Convert.ToInt32(Math.Round(a));

            string binary = Convert.ToString(roundedNumber, 2);

            return binary;
        }

        public int Round(decimal a)
        {
            int roundedNumber = Convert.ToInt32(Math.Round(a));

            return roundedNumber;
        }
    }
}
