using System.Text;
using Programming_Patterns.Builder.Contracts;
using Programming_Patterns.Builder.Enums;
using Programming_Patterns.Shared;

namespace Programming_Patterns.Builder.Models
{
    internal class Box : IMailContainer
    {
        public float DimensionBase { get; set; }
        public float DimensionFront { get; set; }
        public float DimensionPile { get; set; }
        public float WeightOfContents { get; set; }

        [Printable("Weight", unit: "g.")]
        private float WeightOfBox { get; set; }

        [Printable("Volume", unit: "cm3")]
        private float VolumeOfBox { get; set; }

        [Printable("Size")]
        public BoxSize Size { get; set; }

        private const float WeightDifference = 0.1f;

        private const float PHI_RATIO = 1.61803398875f;

        public Box(BoxSize size)
        {
            DimensionBase = (int)size;
            SetDimensions();
        }

        private void SetDimensions()
        {
            DimensionFront = DimensionBase * PHI_RATIO;
            DimensionPile = DimensionBase / PHI_RATIO;
        }

        public float GetVolume()
        {
            this.VolumeOfBox = this.DimensionBase * this.DimensionFront * this.DimensionPile;
            return VolumeOfBox;
        }

        public float GetWeight()
        {
            this.WeightOfBox = this.WeightOfContents + WeightDifference;
            return WeightOfBox;
        }

        public override string ToString()
        {
            string description = new DataClassPrinter<Box>(
                instanceToPrint: this,
                starterString: "Box"
            ).ProduceToString();
            return description.ToString();
        }
    }
}
