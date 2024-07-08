namespace Programming_Patterns.State
{
    internal class InReviewState : State
    {
        public new string StateName { get; set; } = "In Review";

        public override void AddClaims(string claim)
        {
            this.CurrentComplaint.Claims.Add(claim);
            UpdateLastModifiedDate();
        }

        public override void Approve()
        {
            this.CurrentComplaint.CurrentState = new ApprovedState();
            UpdateLastModifiedDate();
        }

        public override void ChangeTitle(string title)
        {
            this.CurrentComplaint.Title = title;
            UpdateLastModifiedDate();
        }

        public override void Close()
        {
            this.CurrentComplaint.CurrentState = new ClosedState();
            UpdateLastModifiedDate();
        }

        public override void Reject()
        {
            this.CurrentComplaint.CurrentState = new RejectedState();
            UpdateLastModifiedDate();
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
            base.Review();
        }
    }
}
