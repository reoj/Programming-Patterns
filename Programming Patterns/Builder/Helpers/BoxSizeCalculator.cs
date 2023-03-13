using Programming_Patterns.Builder.Models;

namespace Programming_Patterns.Builder.Enums
{
    public class BoxSizeCalculator
    {
        public static BoxSize FindBoxSize(Contents contents)
        {
            List<BoxSize> boxSizes = BoxSize.GetValues(typeof(BoxSize)).Cast<BoxSize>().ToList();
            foreach (var boxSize in boxSizes)
            {
                var currentBoxVolume = Math.Pow((int)boxSize, 3);
                if (contents.Volume <= currentBoxVolume)
                {
                    return boxSize;
                }
            }
            return BoxSize.Special;
        }
    }
}
