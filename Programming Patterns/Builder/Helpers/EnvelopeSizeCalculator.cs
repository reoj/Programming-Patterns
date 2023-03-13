namespace Programming_Patterns.Builder.Enums
{
    public class EnvelopeSizeCalculator
    {
        private const decimal MinHeight = 21m;
        private const decimal Ratio = 1.414m;

        public static EnvelopSize GetMinEnvelopeSize(PaperSize envelopType)
        {
            return envelopType switch
            {
                PaperSize.Letter => new EnvelopSize() { Width = 28, Height = 22 },
                PaperSize.A4 => CalculateSizeBasedOnType(PaperSize.A4),
                PaperSize.A3 => CalculateSizeBasedOnType(PaperSize.A3),
                PaperSize.A2 => CalculateSizeBasedOnType(PaperSize.A2),
                PaperSize.A1 => CalculateSizeBasedOnType(PaperSize.A1),
                PaperSize.A0 => CalculateSizeBasedOnType(PaperSize.A0),
                _ => new EnvelopSize() { Width = 30, Height = 30 },
            };
        }

        private static EnvelopSize CalculateSizeBasedOnType(PaperSize envelopType)
        {
            decimal width = MinHeight * Ratio * (int)envelopType;
            decimal height = MinHeight * (int)envelopType;
            return new EnvelopSize() { Width = width, Height = height };
        }
    }
}
