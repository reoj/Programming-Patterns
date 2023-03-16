using Programming_Patterns.Bridge.Contracts;

namespace Programming_Patterns.Bridge.Models
{
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) => Name = nameof(Triangle);
    }
}
