using Programming_Patterns.Builder.Models;

namespace Programming_Patterns.Builder
{
    public class PackageInventory
    {
        public static List<Package> inventory = new List<Package>();
        public static void Add(Package member) => inventory.Add(member);

        public static Package Get(Guid givenID)
        {
            var found = inventory.Find(aPackage => aPackage.ID == givenID);
            return found ?? throw new NullReferenceException();
        }

        public Package this[Guid id] => Get(id); //Indexer

        public static void Remove(Guid guid)
        {
            var packageToRemove = Get(guid);
            if (packageToRemove is not null)
            {
                inventory.Remove(packageToRemove);
            }
        }

        internal static string PrintAll()
        {
            string description = "All Packages: \n:::::::::::::::\n";
            inventory.ForEach(package => description += package.ToString() + "\n");
            return description;
        }
    }
}