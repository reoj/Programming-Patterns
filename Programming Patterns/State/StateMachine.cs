using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming_Patterns.State
{
    public class StateMachine
    {
        private static List<Complaint> complaintsTable = new List<Complaint>();
        public static void AddComplaint(string title)
        {
            complaintsTable.Add(new Complaint(title));
        }
        public static void AddClaims(int complaintIndex, string claim)
        {
            complaintsTable[complaintIndex].AddClaims(claim);
        }
        public static void Approve(int complaintIndex)
        {
            complaintsTable[complaintIndex].Approve();
        }
        public static void Reject(int complaintIndex)
        {
            complaintsTable[complaintIndex].Reject();
        }
        public static void Close(int complaintIndex)
        {
            complaintsTable[complaintIndex].Close();
        }
        public static void Reopen(int complaintIndex)
        {
            complaintsTable[complaintIndex].Reopen();
        }
        public static void ChangeTitle(int complaintIndex, string title)
        {
            complaintsTable[complaintIndex].ChangeTitle(title);
        }
    }
}