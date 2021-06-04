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

        [Fact]
        public void AddTwoNumbers()
        {
            _sut.Add(5);
            _sut.Add(2);

            Assert.Equal(7, _sut.Value);
        }

    }
}

