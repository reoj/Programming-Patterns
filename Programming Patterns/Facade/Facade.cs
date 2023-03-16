namespace Coding.Exercise
{
    public class MagicSquareGenerator
    {
        private Generator generator = new Generator();
        private Splitter splitter = new Splitter();
        private Verifier verifier = new Verifier();

        private int Size { get; set; }

        public List<List<int>> Generate(int size)
        {
            this.Size = size;
            return CycleUntilARandomSquareIsMagic();
        }

        private List<List<int>> CycleUntilARandomSquareIsMagic()
        {
            while (true)
            {
                var square = PopulateFromGenerator();
                bool isMagic = CallVerifierOn(square);
                if (isMagic)
                    return square;
            }
        }

        private List<List<int>> PopulateFromGenerator()
        {
            List<List<int>> square = new List<List<int>>();
            for (int iteration = 0; iteration < Size; ++iteration)
                square.Add(GenerateNewLine());
            return square;
        }

        private List<int> GenerateNewLine() => generator.Generate(Size);

        private List<List<int>> GetSplited(List<List<int>> square) => splitter.Split(square);

        private bool CallVerifierOn(List<List<int>> square)
        {
            var splited = GetSplited(square);
            bool isMagic = verifier.Verify(splited);
            return isMagic;
        }
    }
}
