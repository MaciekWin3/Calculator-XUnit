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
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);

            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach(var value in valuesToAdd)
            {
                _sut.Add(value);
            }

            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { -10, new decimal[] { -30, 20 } };
        }

        //Subtract

        [Theory]
        [InlineData(12, 22, 10)]
        [InlineData(-4, -5, 1)]
        [InlineData(-5, 0, 5)]
        [InlineData(2000, 2546, 546)]
        [InlineData(10, 15, 5)]
        public void SubtractTwoNumbersTheory(decimal expected, decimal firstToSubtract, decimal secondToSubtract)
        {
            _sut.Subtract(firstToSubtract);
            _sut.Subtract(secondToSubtract);

            Assert.Equal(expected, _sut.Value);
        }

        //Multiply

        //Divide

    }
}

