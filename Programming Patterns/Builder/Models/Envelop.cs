using Programming_Patterns.Builder.Contracts;

namespace Programming_Patterns.Builder.Models
{
    internal class Envelop:IMailContainer
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public int MaxPaperSheets { get; set; }
        public int PaperSheetCount { get; set; }

        private const float PaperSheetWeight = 0.1f;
        private const float PaperSheetVolume = 0.0001f;
        private const float EnvelopWeight = 0.1f;

        public float GetVolume()
        {
            return PaperSheetVolume * PaperSheetCount + Width * Height;
        }

        public float GetWeight()
        {
            return PaperSheetWeight * PaperSheetCount + EnvelopWeight;
        }
    }
}
