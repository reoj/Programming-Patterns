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
                LetUserChooseTypeOfBuilder();
            }
        }

        private static bool DecideToStartNewPackage()
        {
            var options = new List<string> { "Exit", "Begin Creation of a Package" };
            var userInputHandler = new UserInputHandler(options);
            userInputHandler.Prompt();

            bool userWantsToCreateAPackage = userInputHandler.SelectedOption == 1;
            return userWantsToCreateAPackage;
        }

        private static void LetUserChooseTypeOfBuilder()
        {
            var options = new List<string> { "Exit", "Box Package", "Envelope Package" };
            var userInputHandler = new UserInputHandler(options);
            userInputHandler.Prompt();

            switch (userInputHandler.SelectedOption)
            {
                case 0:
                    break;
                case 1:
                    CallBoxBuilder();
                    break;
                case 2:
                    CallEnvelopeBuilder();
                    break;
                default:
                    break;
            }
        }

        private static void CallEnvelopeBuilder()
        {
            throw new NotImplementedException();
        }

        private static void CallBoxBuilder()
        {
            Console.WriteLine("::: Box Package Builder :::");
            Console.WriteLine("Submit the Weight of the Package");
            float weigh = UserInputHandler.GetFloatFromUser();
            var boxPackageBuilder = new BoxPackageBuilder(new Contents(weigh));
        }

        private static void ShowResultToUser(Package createdPackage)
        {
            Console.WriteLine("Created a New Package:");
            Console.WriteLine(createdPackage);
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
