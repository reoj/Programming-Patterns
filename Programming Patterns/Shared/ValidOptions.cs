namespace Programming_Patterns.Shared
{
    public class ValidOptions
    {
        public int CountValidOptions { get; init; } = 2;
        public Dictionary<int, string>[] Options { get; set; }

        public ValidOptions(List<string> givenOptions)
        {
            this.CountValidOptions = givenOptions.Count;
            Options = new Dictionary<int, string>[CountValidOptions];
            Options = givenOptions
                .Select((option, index) => new Dictionary<int, string> { { index, option } })
                .ToArray();
        }
    }
}
