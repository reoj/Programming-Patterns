namespace Coding.Exercise
{
    public class Verifier
    {
        public bool Verify(List<List<int>> array)
        {
            bool ArrayIsEmpty = !array.Any();
            if (ArrayIsEmpty)
                return false;

            int expectedResultOfSum = array.First().Sum();
            return AreAllSumsWhatExpected(array, expectedResultOfSum);
        }

        private static bool AreAllSumsWhatExpected(List<List<int>> array, int expected) =>
            array.All(RowsColsOrDiagonals => RowsColsOrDiagonals.Sum() == expected);
    }
}
