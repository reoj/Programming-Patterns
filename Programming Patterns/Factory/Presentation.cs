using Programming_Patterns.Factory.Enums;
using Programming_Patterns.Factory.Models;

namespace Programming_Patterns.Factory
{
    internal class Presentation
    {
        bool KeepRunning = true;

        public void Start()
        {
            while (KeepRunning)
            {
                DisplayMenu();
                ManageOption(GetOptionFromUser());
                KeepRunning = CheckIfContinue();
            }
            Console.WriteLine("Goodbye!");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("::: Membership Factory :::");
            Console.WriteLine("Type Option number and press [ENTER]");
            Console.WriteLine($"[ {(int)MembershipType.Classic} ] Create Classic Membership");
            Console.WriteLine($"[ {(int)MembershipType.Premium} ] Create Premium Membership");
            Console.WriteLine($"[ {(int)MembershipType.Gold} ] Create Gold Membership");
            Console.WriteLine($"[ {(int)MembershipType.Reserved} ] Create VIP Membership");
            Console.WriteLine("[ 9 ] View All Memberships");
            Console.WriteLine("[ 0 ] Exit");
        }

        private static void ManageOption(int selectedOption)
        {
            bool userWantsToCreateAMembership = selectedOption is > 0 and < 9;
            bool userWantsToViewStorage = selectedOption == 9;
            if (userWantsToViewStorage)
            {
                Console.WriteLine(MembershipStorage.PrintAll());
            }

            if (userWantsToCreateAMembership)
            {
                string username = RequestUsername();
                Membership createdMembership = BuildMembership(selectedOption, username);
                ShowResultToUser(createdMembership);
            }
        }

        private static void ShowResultToUser(Membership createdMembership)
        {
            Console.WriteLine("Created a New Membership:");
            Console.WriteLine(createdMembership);
        }

        private static Membership BuildMembership(int selectedOption, string username)
        {
            MembershipType type = (MembershipType)selectedOption;
            var createdMembership = MembershipFactory.CreateMembership(username, type);
            MembershipStorage.Add(createdMembership);
            return createdMembership;
        }

        private static int GetOptionFromUser()
        {
            string? rawInput = Console.ReadLine();
            return rawInput is null ? 0 : int.Parse(rawInput);
        }

        private static string RequestUsername()
        {
            string name = String.Empty;
            while (name.Length == 0)
            {
                name = RequireUserName();
            }
            return name;
        }

        private static string RequireUserName()
        {
            Console.WriteLine("Username? ");
            string? rawInput = Console.ReadLine();
            return rawInput is null ? String.Empty : rawInput.Trim();
        }

        public static bool CheckIfContinue()
        {
            Console.WriteLine("Stop? [Y/N]");
            string? responseRaw = Console.ReadLine();
            char option = responseRaw is null ? 'N' : responseRaw.Trim().ToUpper()[0];

            return option != 'Y';
        }
    }
}
