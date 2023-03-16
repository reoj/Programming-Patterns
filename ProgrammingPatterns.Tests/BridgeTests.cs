using Programming_Patterns.Bridge;
using Programming_Patterns.Bridge.Contracts;
using Programming_Patterns.Bridge.Models;

namespace ProgrammingPatterns.Tests
{
    [Trait("Category", "Bridge")]
    public class BridgeTests
    {
        [Fact]
        public void ToString_WhenCalled_ReturnsRenderingMessage()
        {
            //Arrange
            IRenderer renderer = new RasterRenderer();
            Shape underTest = new Triangle(renderer);

            //Act
            string result = underTest.ToString();

            //Assert
            Assert.Equal(expected:"Drawing Triangle as pixels", actual:result);
        }
    }
}
