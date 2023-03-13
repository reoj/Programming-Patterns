using Programming_Patterns.Shared;

namespace Programming_Patterns.Builder
{
    public class UserInputHandler
    {
        public int SelectedOption { get; set; } = 0;
        public ValidOptions RegisteredOptions { get; set; }
        public string UserRawInput { get; set; } = String.Empty;
        public string Question { get; set; }
        public bool KeepAsking { get; set; }

        private const string DefaultQuestion = "Type Option number and press [ENTER]";

        public UserInputHandler(List<string> options, string question = DefaultQuestion)
        {
            this.RegisteredOptions = new ValidOptions(options);
            this.Question = question;
        }

        public void Prompt()
        {
            while (KeepAsking)
            {
                try
                {
                    AskUser();
                    KeepAsking = false;
                }
                catch (Exception ex)
                {
                    KeepAsking = true;
                    Console.WriteLine($"{UserRawInput} is not a valid option");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AskUser()
        {
            Console.WriteLine(Question);
            for (
                int optionIndex = 1;
                optionIndex < RegisteredOptions.CountValidOptions;
                optionIndex++
            )
            {
                DisplaySingleOption(optionIndex);
            }
            DisplaySingleOption(0);
            SelectedOption = GetOptionFromUser();
            SelectedOption = ValidateOption(SelectedOption);

            void DisplaySingleOption(int optionIndex)
            {
                Console.WriteLine($"[ {optionIndex} ] {RegisteredOptions.Options[optionIndex]}");
            }
        }

        private int GetOptionFromUser()
        {
            UserRawInput = Console.ReadLine() ?? String.Empty;
            int option;
            bool isInputInvalid = !int.TryParse(UserRawInput.Trim(), out option);
            if (isInputInvalid)
            {
                throw new ArgumentException("Input is not a number");
            }
            return option;
        }

        private int ValidateOption(int option)
        {
            if (option <= 0 || option > RegisteredOptions.CountValidOptions)
            {
                throw new ArgumentOutOfRangeException(nameof(option));
            }
            return option;
        }

        public static float GetFloatFromUser()
        {
            var userRawInput = Console.ReadLine();
            string userInputAsString = userRawInput is not null
                ? userRawInput.Trim()
                : String.Empty;
            bool isInputInvalid = !float.TryParse(userInputAsString, out float option);
            if (isInputInvalid)
            {
                throw new ArgumentException("Input is not a number");
            }
            return option;
        }
    }
}
