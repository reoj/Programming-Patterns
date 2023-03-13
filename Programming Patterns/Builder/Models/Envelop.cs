using Programming_Patterns.Builder.Contracts;
using Programming_Patterns.Builder.Enums;

namespace Programming_Patterns.Builder.Models
{
    internal class Envelope : IMailContainer
    {
        public decimal Width { get; private set; }

        public decimal Height { get; private set; }
        public int MaxPaperSheets { get; set; }
        public int PaperSheetCount { get; set; }

        private const decimal PaperSheetWeight = 0.1m;
        private const decimal PaperSheetVolume = 0.0001m;
        private const decimal EnvelopWeight = 0.1m;

        internal Envelope(int paperSheetCount, PaperSize size)
        {
            this.PaperSheetCount = paperSheetCount;
            SetSize(size);
        }

        public void SetSize(PaperSize size)
        {
            var dimensions = EnvelopeSizeCalculator.GetMinEnvelopeSize(size);
            Width = dimensions.Width;
            Height = dimensions.Height;
        }

        public decimal GetVolume() => PaperSheetVolume * PaperSheetCount + Width * Height;

        public decimal GetWeight() => PaperSheetWeight * PaperSheetCount + EnvelopWeight;
    }
}
