namespace Programming_Patterns.State
{
    internal class RejectedState : State
    {
        public new string StateName { get; set; } = "Rejected";

        public override void AddClaims(string claim) =>
            throw new InvalidOperationInCurrentStateException(
                operation: "AddClaims",
                state: this.StateName
            );

        public override void Approve() => throw new ReopenRequiredException(StateName);

        public override void ChangeTitle(string title) =>
            throw new InvalidOperationInCurrentStateException(
                operation: "AddClaims",
                state: this.StateName
            );

        public override void Close()
        {
            this.CurrentComplaint.CurrentState = new ClosedState();
            UpdateLastModifiedDate();
        }

        public override void Reject()
        {
            throw new DuplicateOperationException(this.StateName);
        }

        public override void Reopen()
        {
            this.CurrentComplaint.CurrentState = new OpenState();
            UpdateLastModifiedDate();
        }

        public override void Review()
        {
            base.Review();
            Console.WriteLine(
                "This complaint has been rejected. on " + this.CurrentComplaint.DateLastUpdate
            );
        }
    }
}
