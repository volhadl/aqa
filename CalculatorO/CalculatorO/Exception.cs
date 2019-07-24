using System;


namespace CalculatorO
{
    public class IncorrectInputException : Exception
    {
        public IncorrectInputException()
        {
        }
        public IncorrectInputException(string message) : base(message)
        {
        }
    }
    public class EmptyHistoryException : Exception
    {
        public EmptyHistoryException()
        {
        }
        public EmptyHistoryException(string message) : base(message)
        {
        }
    }
}