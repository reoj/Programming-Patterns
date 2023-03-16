namespace Coding.Exercise
{
    public class Generator
    {
        private static readonly Random random = new Random();
        private readonly int LowerBound = 1;
        private readonly int UpperBound = 6;

        public List<int> Generate(int count) =>
            Enumerable
                .Range(start: 0, count: count)
                .Select(_ => GetRandomNumberInBounds())
                .ToList();

        private int GetRandomNumberInBounds()
        {
            return random.Next(LowerBound, UpperBound);
        }
    }
}
