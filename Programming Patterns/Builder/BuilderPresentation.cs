using Programming_Patterns.Builder.Enums;
using Programming_Patterns.Builder.Models;

namespace Programming_Patterns.Builder
{
    internal class Presentation
    {
        bool KeepRunning = true;

        public void Start()
        {
            while (KeepRunning)
            {
                DisplayMenu();
                KeepRunning = CheckIfContinue();
            }
            Console.WriteLine("Goodbye!");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("::: Package Builder :::");
            if (DecideToStartNewPackage()) 
            { 
                CallBuilder();
            }
        }

        private static bool DecideToStartNewPackage()
        {
            var options = new List<string> { "Exit", "Begin Creation of a Package" };
            var userInputHandler = new UserInputHandler(
                options
            );
            userInputHandler.Prompt();

            bool userWantsToCreateAPackage = userInputHandler.SelectedOption == 1;
            return userWantsToCreateAPackage;
        }

        private static void CallBuilder() 
        { 

        }

        private static void ShowResultToUser(Package createdPackage)
        {
            Console.WriteLine("Created a New Package:");
            Console.WriteLine(createdPackage);
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
