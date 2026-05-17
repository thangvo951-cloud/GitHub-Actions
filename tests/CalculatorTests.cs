using Xunit;
using MyProject;

namespace MyProject.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldReturnCorrectSum()
        {
            var calc = new Calculator();
            var result = calc.Add(3, 6);
            Assert.Equal(36, result);
        }
    }
}