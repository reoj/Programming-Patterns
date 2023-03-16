using Programming_Patterns.Bridge.Contracts;

namespace Programming_Patterns.Bridge.Models
{
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) => Name = nameof(Square);
    }
}
