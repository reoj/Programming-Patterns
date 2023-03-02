namespace Programming_Patterns.Factory
{
    internal static class FactoryController
    {
        internal static readonly MembershipStorage Storage = new();
        internal static readonly MembershipFactory Factory = new();
        private static readonly Presentation Presentation = new();

        static FactoryController() { }

        public static void Run()
        {
            Presentation.Start();
        }
    }
}
