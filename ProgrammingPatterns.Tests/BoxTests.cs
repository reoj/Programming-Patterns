using Programming_Patterns.Builder.Enums;
using Programming_Patterns.Builder.Models;

namespace ProgrammingPatterns.Tests
{
    [Trait("Category", value: "Box")]
    public class BoxTests
    {
        [Fact]
        public void Box_WhenCreatedWithWeigh_HasWeigh()
        {
            // Arrange
            var aRandomWeigh = 11.2m;

            // Act
            var testObj = new Box(size: BoxSize.Large) { WeightOfContents = aRandomWeigh };
            var contentWeigh = testObj.WeightOfContents;
            var fullWeigh = testObj.GetWeight();
            // Assert
            Assert.Equal(expected: 12, actual: contentWeigh);
            Assert.Equal(expected: 12.1m, actual: fullWeigh);
            Assert.Contains(expectedSubstring: "12.1 g.", actualString: testObj.ToString());
        }

        [Fact]
        public void Box_WhenCreated_HasDimensions()
        {
            // Arrange
            var aChosenSize = BoxSize.Large;
            string baseDimension = ((int)aChosenSize).ToString();

            // Act
            var testObj = new Box(size: aChosenSize);
            var boxDimensions = testObj.AllDimensions;
            var printed = testObj.ToString();

            // Assert
            Assert.Contains(expectedSubstring: baseDimension, actualString: boxDimensions);
            Assert.Contains(expectedSubstring: " x ", actualString: printed);
        }
    }
}
