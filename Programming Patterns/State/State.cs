using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Patterns.State
{
    public abstract class State
    {
        public string StateName { get; set; } = "Operation";
        public Complaint CurrentComplaint { get; set; }
        private DateTime StartedDate { get; set; } = DateTime.Now;

        public State()
        {
            StartedDate = DateTime.Now;
        }

        public abstract void AddClaims(string claim);
        public abstract void Approve();
        public abstract void Reject();
        public abstract void Close();

        public virtual void Review()
        {
            StringBuilder logOfClaims = new StringBuilder();
            foreach (var claim in this.CurrentComplaint.Claims)
            {
                logOfClaims.Append(claim);
                logOfClaims.Append("\n");
            }
            Console.WriteLine(logOfClaims.ToString());
        }

        public abstract void Reopen();
        public abstract void ChangeTitle(string title);

        public void UpdateLastModifiedDate()
        {
            this.CurrentComplaint.DateLastUpdate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{this.StateName} on {this.StartedDate}";
        }
    }
}
