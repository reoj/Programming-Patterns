namespace Programming_Patterns.State
{
    internal class ClosedState : State
    {
        public new string StateName { get; set; } = "Closed";

        public override void AddClaims(string claim)
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void Approve()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void ChangeTitle(string title)
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void Close()
        {
            throw new DuplicateOperationException(StateName);
        }

        public override void Reject()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void Reopen()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void Review()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }
    }
}
