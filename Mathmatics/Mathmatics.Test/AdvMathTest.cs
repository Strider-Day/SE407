using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mathmatics.Test
{
    public class AdvMathTest : IClassFixture<AdvMathTestFixture>
    {
        private AdvMathTestFixture _fixture;

        public AdvMathTest(AdvMathTestFixture fixture)
        {
            _fixture = fixture;
        }
        [Theory]
        [InlineData(5, 4, 20)]
        [InlineData(3, 12, 36)]
        public void TestCalcArea(int num1, int num2, int expectedResult)
        {
            int result = _fixture.TestObject.CalcArea(num1, num2);
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData(new [] { 3.0, 4.0, 3.0, 2.0 }, 3.0)]
        [InlineData(new [] { 2.5, 3.0, 2.75}, 2.75)]
        public void TestCalcAverage(double[] values, double expectedResult)
        {
            double result = _fixture.TestObject.CalcAverage(values);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(4, 16)]
        [InlineData(5, 25)]
        public void TestValueSquared(int num, int expectedResult)
        {
            int result = _fixture.TestObject.ValueSquared(num);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 4, 5)]
        public void TestPythagTheoerm(int num1, int num2, double expectedResult)
        {
            double result = _fixture.TestObject.PythagTheoerm(num1, num2);
            Assert.Equal(expectedResult, result);
        }
    }
}
