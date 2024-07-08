using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Patterns.State
{
    public class Complaint
    {
        public State CurrentState { get; set; }
        public string Title { get; set; }
        public List<string> Claims { get; set; }
        public DateTime DateFiled { get; set; }
        public DateTime DateLastUpdate { get; set; }
        private List<string> History { get; set; }

        public Complaint(string title)
        {
            CurrentState = new OpenState();
            DateFiled = DateTime.Now;
            DateLastUpdate = DateTime.Now;
            Title = title;
        }

        public void AddClaims(string claim) => CurrentState.AddClaims(claim);

        public void Approve() => CurrentState.Approve();

        public void Reject() => CurrentState.Reject();

        public void Close() => CurrentState.Close();

        public void Reopen() => CurrentState.Reopen();

        public void ChangeTitle(string title) => CurrentState.ChangeTitle(title);
        public void LogEvent(State changedTo)
        {
            History.Add(changedTo.ToString());
        }
        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.Append($"Complaint: {Title}\n");
            description.Append($"Filed on: {DateFiled}\n");
            description.Append($"Last Updated on: {DateLastUpdate}\n");
            description.Append($"Current State: {CurrentState.StateName}\n");
            description.Append("History:\n");
            foreach (var state in History)
            {
                description.Append(state);
                description.Append("\n");
            }
            return description.ToString();
        }
    }
}
