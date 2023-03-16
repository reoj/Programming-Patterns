using Programming_Patterns.Flyweight;

namespace ProgrammingPatterns.Tests
{
    [Trait("Category", "FlyWeight")]
    public class FlyWeightTests
    {
        [Fact]
        public void SentenceTest()
        {
            //Arrange
            string desired = "hello WORLD";

            //Act
            var sentence = new Sentence("hello world");            
            sentence[1].Capitalize = true;
            string actual = sentence.ToString();

            //Assert
            Assert.Equal(desired, actual);
        }
    }
}