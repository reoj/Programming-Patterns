namespace Programming_Patterns.State
{
    internal class ApprovedState : State
    {
        public new string StateName { get; set; } = "Approved";

        public override void AddClaims(string claim)
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Add Claim",
                state: StateName
            );
        }

        public override void Approve()
        {
            throw new DuplicateOperationException(StateName);
        }

        public override void ChangeTitle(string title)
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Change Title",
                state: StateName
            );
        }

        public override void Close()
        {
            this.CurrentComplaint.CurrentState = new ClosedState();
            UpdateLastModifiedDate();
        }

        public override void Reject()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Reject",
                state: StateName
            );
        }

        public override void Reopen()
        {
            throw new InvalidOperationInCurrentStateException(
                operation: "Reopen",
                state: StateName
            );
        }

        public override void Review()
        {
            base.Review();
            Console.WriteLine(
                "This complaint has been approved. on " + this.CurrentComplaint.DateLastUpdate
            );
        }
    }
}
