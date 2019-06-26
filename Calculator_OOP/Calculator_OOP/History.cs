using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_OOP
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
        } 
       
    }
}
