using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Calculator_2._0
{
    public class HistoryManager
    {
        ArrayList list = new ArrayList();
        public void PrintLog()
        {
            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
        }
    }
}
    /*

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
    }*/
    /*
    public List<BaseOperation> History { get; set; }

    public HistoryManager()
    {
        History = new List<BaseOperation>();
    }
    */
    /*
    List<int[,]> matrixHistory = new List<int[,]>();

    public void AddLog(int[,] mRecord) => matrixHistory.Add(mRecord);

    public void PrintLogM()
    {
        foreach (int[,] mRecord in matrixHistory)
        {
            var matrixPrint = new MathMatrixRunnerMenu();
            matrixPrint.Print(mRecord);
        }
        if (matrixHistory == null || matrixHistory.Count == 0)
            Console.WriteLine("List is either null or empty");
    }
    
}*/

