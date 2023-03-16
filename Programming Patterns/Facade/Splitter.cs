namespace Coding.Exercise
{
    public class Splitter
    {
        private int ColCount { get; set; }
        private int RowCount { get; set; }

        public List<List<int>> Split(List<List<int>> array)
        {
            var result = new List<List<int>>();

            this.RowCount = array.Count;
            this.ColCount = array[0].Count;

            // get the rows
            CopyAllRows(array, result);

            // get the columns
            CopyAllColums(array, result);

            // now the diagonals
            var diag1 = new List<int>();
            var diag2 = new List<int>();
            
            CopyDiagonals(array, diag1, diag2);

            result.Add(diag1);
            result.Add(diag2);

            return result;
        }

        private void CopyDiagonals(List<List<int>> array, List<int> diag1, List<int> diag2)
        {
            for (int c = 0; c < ColCount; ++c)
            {
                for (int r = 0; r < RowCount; ++r)
                {
                    int item = array[r][c];
                    int rTwo = RowCount - r - 1;
                    if (ColNumAndRowNumAreEqual(c, r))
                        diag1.Add(item);
                    if (ColNumAndRowNumAreEqual(c, rTwo))
                        diag2.Add(item);
                }
            }
        }

        private bool ColNumAndRowNumAreEqual(int c, int r) => c == r;

        private void CopyAllColums(List<List<int>> array, List<List<int>> result)
        {
            for (int c = 0; c < ColCount; ++c)
            {
                List<int> theCol = GetSingleCol(array, c);
                result.Add(theCol);
            }
        }

        private List<int> GetSingleCol(List<List<int>> array, int c)
        {
            var theCol = new List<int>();
            for (int r = 0; r < RowCount; ++r)
                theCol.Add(array[r][c]);
            return theCol;
        }

        private void CopyAllRows(List<List<int>> array, List<List<int>> result)
        {
            for (int r = 0; r < RowCount; ++r)
            {
                List<int> theRow = GetSingleRow(array, r);
                result.Add(theRow);
            }
        }

        private List<int> GetSingleRow(List<List<int>> array, int r)
        {
            var theRow = new List<int>();
            for (int c = 0; c < ColCount; ++c)
                theRow.Add(array[r][c]);
            return theRow;
        }
    }
}
