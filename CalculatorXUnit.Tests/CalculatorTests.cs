using CalculatorXUnit.Backend;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorXUnit.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator();
        }

        //Add

        [Theory]
        [InlineData(12, 7, 5)]
        [InlineData(-4, -5, 1)]
        [InlineData(5, 0, 5)]
        [InlineData(2546, 2000, 546)]
        [InlineData(-16, 12, -28)]
        public void AddTwoNumbersTheory(decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            decimal result = _sut.Add(firstToAdd, secondToAdd);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataAdd))]
        public void AddManyNumbersTheory(decimal expected, params decimal[] valuesToAdd)
        {

            decimal result = 0;

            foreach (var value in valuesToAdd)
            {
                result += value;
            }

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestDataAdd()
        {
            yield return new object[] { 15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { -10, new decimal[] { -30, 20 } };
        }

        //Subtract

        [Theory]
        [InlineData(12, 22, 10)]
        [InlineData(-6, -5, 1)]
        [InlineData(-5, 0, 5)]
        [InlineData(2000, 2546, 546)]
        [InlineData(10, 15, 5)]
        public void SubtractTwoNumbersTheory(decimal expected, decimal firstToSubtract, decimal secondToSubtract)
        {
            decimal result = _sut.Subtract(firstToSubtract, secondToSubtract);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataSubtract))]
        public void SubtractManyNumbersTheory(decimal expected, params decimal[] valuesToSubtract)
        {

            decimal value = valuesToSubtract[0];


            for(int i = 1; i < valuesToSubtract.Length; i++)
            {
                value -= valuesToSubtract[i];
            }

            Assert.Equal(expected, value);
        }

        public static IEnumerable<object[]> TestDataSubtract()
        {
            yield return new object[] { 0, new decimal[] { 10, 5, 5 } };
            yield return new object[] { 10, new decimal[] { 45, 35 } };
            yield return new object[] { 25, new decimal[] { 50, 20, 3, 2 } };
        }

        //Multiply

        [Theory]
        [InlineData(22, 2, 11)]
        [InlineData(49, 7, 7)]
        [InlineData(-25, -5, 5)]
        [InlineData(2000, 4, 500)]
        [InlineData(29, 29, 1)]
        public void MultiplyTwoNumbersTheory(decimal expected, decimal firstToMultiply, decimal secondToMultiply)
        {
            decimal result = _sut.Multiply(firstToMultiply, secondToMultiply);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataMulitply))]
        public void MultiplyManyNumbersTheory(decimal expected, params decimal[] valuesToSubtract)
        {

            decimal value = 1;


            for (int i = 0; i < valuesToSubtract.Length; i++)
            {
                value *= valuesToSubtract[i];
            }

            Assert.Equal(expected, value);
        }

        public static IEnumerable<object[]> TestDataMulitply()
        {
            yield return new object[] { 25, new decimal[] { 1, 5, 5 } };
            yield return new object[] { 64, new decimal[] { -8, -8 } };
            yield return new object[] { -50, new decimal[] { 5, -10 } };
            yield return new object[] { 8, new decimal[] { 2, 4 } };
            yield return new object[] { 4, new decimal[] { 2, 2 } };
            yield return new object[] { 144, new decimal[] { 1, 1, 3, 2, 4, 6 } };
        }

        //Divide

        [Theory]
        [InlineData(12, 24, 2)]
        [InlineData(2, -6, -3)]
        [InlineData(2, 10, 5)]
        [InlineData(100, 300, 3)]
        [InlineData(3, 15, 5)]
        public void DivideTwoNumbersTheory(decimal expected, decimal firstToDivide, decimal secondToDivide)
        {
            decimal result = _sut.Divide(firstToDivide, secondToDivide);


            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataDivide))]
        public void DivideManyNumbersTheory(decimal expected, params decimal[] valuesToDivide)
        {

            decimal value = valuesToDivide[0];


            for (int i = 1; i < valuesToDivide.Length; i++)
            {
                value /= valuesToDivide[i];
            }

            Assert.Equal(expected, value);

           
        }

        public static IEnumerable<object[]> TestDataDivide()
        {
            yield return new object[] { 5, new decimal[] { 10, 2 } };
            yield return new object[] { 100, new decimal[] { 500, 5 } };
            yield return new object[] { 50, new decimal[] { 150, 3 } };
            yield return new object[] { 12, new decimal[] { 48, 4 } };
            yield return new object[] { 30, new decimal[] { 300, 10 } };
            yield return new object[] { 2, new decimal[] { 20, 5, 2 } };
        }

        //Divide by 0

        [Theory]
        [InlineData(24, 0)]
        [InlineData(25, 0)]
        [InlineData(-20, 0)]
        [InlineData(0, 0)]
        public void DivideByZeroTheory(decimal firstToDivide, decimal secondToDivide)
        {
           
            Assert.Throws<DivideByZeroException>(() =>
            {
                decimal result = _sut.Divide(firstToDivide, secondToDivide);
            });
        }

        //Convert to binary

        [Theory]
        [InlineData("1001",9)]
        [InlineData("111000",56)]
        [InlineData("10", 2)]
        [InlineData("11", 3)]
        public void ConvertAndRoundToBinaryTheory(string expected, decimal input)
        {
            string result = _sut.RoundAndConvertToBinary(input);

            Assert.Equal(expected, result);
        }

        //Round

        [Theory]
        [InlineData(10.32, 10 )]
        [InlineData(8, 8)]
        [InlineData(-3, -2.87)]
        [InlineData(18, 18.23)]
        [InlineData(19, 18.83)]
        public void RoundDecimalNumberTheory(int expected, decimal input)
        {
            int result = _sut.Round(input);

            Assert.Equal(expected, result);
        }

    }
}

