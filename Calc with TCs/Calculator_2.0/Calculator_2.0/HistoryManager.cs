using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Calculator_2._0
{
    public class HistoryManager
    {


        List<string> history = new List<string>();

        public void AddLog(string record) => history.Add(record);

        public void PrintLog()
        {
            foreach (string record in history)
            {
                Console.WriteLine(record);
            }
            if (history == null || history.Count == 0)
                Console.WriteLine("List is either null or empty");
        }
    }
}