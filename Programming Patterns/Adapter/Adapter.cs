namespace Programming_Patterns.Adapter
{
    public class SquareToRectangleAdapter : IRectangle
    {
        private int width;

        private int height;

        public int Width => width;
        public int Height => height;

        public SquareToRectangleAdapter(Square square)
        {
            this.height = square.Side;
            this.width = square.Side;
        }
    }
}
