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
            //try
            //{
            result = a / b;
            //}
            //catch(DivideByZeroException e)
            //{
            //Console.WriteLine("Cannot divide by 0", e.Message);
            //}

            return result;
        }
    }
}
