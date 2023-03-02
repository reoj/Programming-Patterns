using Programming_Patterns.Factory.Models;

namespace Programming_Patterns.Factory
{
    public class MembershipStorage
    {
        private static List<Membership> Members { get; } = new();

        public static void Add(Membership member) => Members.Add(member);

        public static Membership Get(Guid memberId)
        {
            var found = Members.Find(aMembership => aMembership.Id == memberId);
            return found ?? throw new NullReferenceException();
        }

        public Membership this[Guid id] => Get(id); //Indexer

        public static void Remove(Guid guid)
        {
            var memberToRemove = Get(guid);
            if (memberToRemove is not null)
            {
                Members.Remove(memberToRemove);
            }
        }

        internal static string PrintAll()
        {
            string description = "All Memberships: \n:::::::::::::::\n";
            Members.ForEach(member => description += member.ToString() + "\n");
            return description;
        }
    }
}
