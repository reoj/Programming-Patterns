using Programming_Patterns.Factory.Enums;
using Programming_Patterns.Factory.Models;

namespace Programming_Patterns.Factory
{
    internal class MembershipFactory
    {
        public static Membership CreateMembership(string member, MembershipType typeOfMember)
        {
            return typeOfMember switch
            {
                MembershipType.Classic => CreateClassic(member),
                MembershipType.Premium => CreatePremium(member),
                MembershipType.Gold => CreateGold(member),
                MembershipType.Reserved => CreateReserved(member),
                _ => throw new ArgumentException("Invalid Membership"),
            };
        }

        private static Membership CreateClassic(string username)
        {
            return new Membership(username)
            {
                Type = MembershipType.Classic,
                Expiry = DateTime.Now.AddYears(1),
                RightToYearlyGift = false,
                DiscountPercentage = 10,
            };
        }

        private static Membership CreatePremium(string username)
        {
            return new Membership(username)
            {
                Type = Factory.Enums.MembershipType.Premium,
                Expiry = DateTime.Now.AddYears(3),
                RightToYearlyGift = false,
                AccessToPool = true,
                DiscountPercentage = 15,
            };
        }

        private static Membership CreateGold(string username)
        {
            return new Membership(username)
            {
                Type = Factory.Enums.MembershipType.Gold,
                Expiry = DateTime.Now.AddYears(5),
                RightToYearlyGift = true,
                AccessToPool = true,
                DiscountPercentage = 25,
            };
        }

        private static Membership CreateReserved(string username)
        {
            return new Membership(username)
            {
                Type = MembershipType.Reserved,
                Expiry = DateTime.Now.AddYears(99),
                RightToYearlyGift = true,
                AccessToPool = true,
                DiscountPercentage = 30
            };
        }
    }
}
