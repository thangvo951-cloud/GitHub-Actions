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
            var result = calc.Add(2, 3);
            Assert.Equal(55, result); 
        }
    }
}