using Programming_Patterns.Factory.Enums;
using System.Text;

namespace Programming_Patterns.Factory.Models
{
    public class Membership
    {
        public Guid Id { get; }
        public MembershipType Type { get; internal set; }
        public string OwnerName { get; set; }
        public DateTime Created { get; }
        public DateTime Expiry { get; set; }
        public bool AccessToPool { get; internal set; }
        public bool RightToYearlyGift { get; internal set; }
        public float DiscountPercentage { get; internal set; }

        public Membership(string UserName)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            OwnerName = UserName;
        }

        public override string ToString()
        {
            StringBuilder descriptionBuilder = new StringBuilder();
            string description = "";
            List<string> labels =
                new()
                {
                    "Membership",
                    "ID",
                    "Owner",
                    "Created",
                    "Expiry",
                    "Has Access to the Pool?",
                    "Yearly Gift Benefits?",
                    "Discount"
                };
            List<string> atribs =
                new()
                {
                    Type.ToString(),
                    Id.ToString(),
                    OwnerName,
                    Created.ToString(),
                    Expiry.ToString(),
                    AccessToPool.ToString(),
                    RightToYearlyGift.ToString(),
                    DiscountPercentage.ToString() + '%',
                };

            string eachLabelWithEachAttribute(string aLabel, int index) =>
                AddAttributeDescription(aLabel, atribs[index]);

            void labeledAttributeAddItToDescription(string labeled) => description += labeled;

            labels
                .Select(eachLabelWithEachAttribute)
                .ToList()
                .ForEach(labeledAttributeAddItToDescription);

            return description;
        }

        private static string AddAttributeDescription(string label, string data) =>
            $"{label}: {data}\n";
    }
}
