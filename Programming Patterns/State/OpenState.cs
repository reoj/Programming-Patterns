namespace Programming_Patterns.State
{
    public class OpenState : State
    {
        public new string StateName { get; set; } = "Open";

        public override void AddClaims(string claim)
        {
            this.CurrentComplaint.Claims.Add(claim);
            UpdateLastModifiedDate();
        }

        public override void Approve() => throw new ReviewRequiredException();

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

        public override void Reject() => throw new ReviewRequiredException();

        public override void Reopen()
        {
            throw new DuplicateOperationException("Open");
        }

        public override void Review()
        {
            this.CurrentComplaint.CurrentState = new InReviewState();
            UpdateLastModifiedDate();
        }
    }
}
