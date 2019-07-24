using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO
{
  internal  class IoManager
    {
       internal static string ReadOperand(string input)
        {
            Console.WriteLine(input);
            string operand = Console.ReadLine();
            return operand;
        }
        internal static string CreateString(int[,] a, string message)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (i > 0) message += ',';
                message += '{';
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j > 0) message += ',';
                    message += a[i, j];
                }
                message += '}';
            }
            return message;
        }

        internal static void Print(int[,] a, string message)
        {
            message = CreateString(a, message);
            Console.WriteLine(message);
        }
        internal static void WriteOperand(string input)
        {
            Console.WriteLine(input);
        }

        internal static bool Checker(int[,] lastresult)
        {
            bool isFirstLoop;
            if (lastresult != null)
            {
                isFirstLoop = false;
                Print(lastresult, Calculator.a);
            }
            else
            {
                isFirstLoop = true;
                WriteOperand(Calculator.a);
            }
            return isFirstLoop;
        }
        internal static bool CheckerN(double LastResult)
        {
            bool isFirstLoop;
            if (LastResult == 0)
            {
                isFirstLoop = true;
            }
            else
            {
                isFirstLoop = false;
                Console.WriteLine($"first operand =  {LastResult}");
            }
            return isFirstLoop;
        }
    }
}
