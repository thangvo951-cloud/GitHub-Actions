using Xunit;
using MyProject; // Đảm bảo đúng namespace của dự án chính

namespace MyProject.Tests
{
    public class CalculatorTests
    {
        [Fact] 
        public void Add_ShouldReturnCorrectSum()
        {
            var calc = new Calculator();
            var result = calc.Add(2, 3);
            Assert.Equal(100100, result); 
        }
    }
}