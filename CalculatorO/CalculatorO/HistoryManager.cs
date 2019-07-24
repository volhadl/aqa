using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CalculatorO
{
    public static class HistoryManager
    {

       public static List<string> history = new List<string>();

        public static void AddLog(string record) => history.Add(record);

        public static void PrintLog()
        {
            foreach (string record in history)
            {
                Console.WriteLine(record);
            }
            if (history == null || history.Count == 0)
                throw new EmptyHistoryException("List is either null or empty");
            //  Console.WriteLine("List is either null or empty");
        }
    }
}
