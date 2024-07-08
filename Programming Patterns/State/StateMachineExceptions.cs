using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming_Patterns.State
{
    public class InvalidOperationInCurrentStateException : Exception
    {
        public InvalidOperationInCurrentStateException(string operation, string state)
            : base($"Operation {operation} is invalid because the complaint is {state}") { }
    }
    public class ReopenRequiredException : Exception
    {
        public ReopenRequiredException(string state)
            : base($"To execute this Operation, the complaint must be reopened first because the complaint is {state}") { }
    }
    public class ReviewRequiredException : Exception
    {
        public ReviewRequiredException()
            : base($"To execute this Operation, the complaint must be reviewed first") { }
    }
    public class DuplicateOperationException : Exception
    {
        public DuplicateOperationException(string operation)
            : base($"Operation {operation} has already been completed") { }
    }
}
