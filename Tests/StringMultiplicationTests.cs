using BinaryTreeMirroring;
using StringMultiplication;
using System.Text;
using Xunit.Sdk;

namespace Tests
{
    /// <summary>
    /// Тесты на <see cref="StringMultiplication.StringMultiplier"/>
    /// </summary>
    public class StringMultiplicationTests
    {
        [Theory]
        [InlineData("1", "1")]
        [InlineData("1", "12")]
        [InlineData("12", "1")]
        [InlineData("9", "9")]
        [InlineData("01", "01")]
        [InlineData("09", "09")]
        [InlineData("0", "0")]
        [InlineData("0", "01")]
        [InlineData("01", "0")]
        [InlineData("0", "123")]
        [InlineData("123", "0")]
        [InlineData("999", "9")]
        [InlineData("9", "999")]
        [InlineData("999", "999")]
        [InlineData("-1", "0")]
        [InlineData("0", "-1")]
        [InlineData("-1", "-1")]
        [InlineData("1", "-1")]
        [InlineData("-1234", "4321")]
        public void TestStringMultiplication(string value1, string value2)
        {
            var result = int.Parse(StringMultiplier.Multiply(value1, value2));

            var expected = int.Parse(value1) * int.Parse(value2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestVeryLongValues()
        {
            var value1 = "111111111111111111111111111111";
            var value2 = "22222222222222222222222222222222";
            var expectedResult = "2469135802469135802469135802466641975308641975308641975308642";

            var actualRresult = StringMultiplier.Multiply(value1, value2);
            Assert.Equal(expectedResult, actualRresult);
        }
    }
}