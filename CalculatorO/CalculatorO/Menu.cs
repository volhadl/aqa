using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CalculatorO
{
    /*
    public class SetArguments
    {
        public double FirstArgument { get; set; }
        public double SecondArgument { get; set; }
    }
    */
    
    public abstract class Menu
    {
        public Operations Operation { get; set; }
        public string operationInput {get; set;}
        public double LastResult { get; set; }
        public int[,] LastResultMatrix { get; set; }
        public bool isFirstLoop { get; set; }
        public double FirstArgument { get; set; }
        public double SecondArgument { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public int[,] Matrix1 { get; set; }
        public int[,] Matrix2 { get; set; }

        //public double num1;
        // public double num2;
        public string firstMsg = "Please, Enter first operand";
        public string secondMsg = "Please, Enter second operand";
        public string weightMsg = "Input YOUR weight in kg: ";
        public string heightMsg = "Input YOUR height in m: ";
        public string rowMsg = "row matrix: ";
        public string columnMsg = "column matrix: ";

        string[] Options = new string[9] { "+", "-", "*", "/", "b", "m", "h", "c", "q" };
        protected bool ValidateInputs(string input) => Options.Any(i => i.Equals(input));
    }

    public class MainMenu : Menu
    {
        public string GetInputForOperations(string input = null)
        {
            Console.WriteLine("\n Select operation: '+'\t '-'\t '*'\t '/' " +
                                             " \n \t\t  'b' - for count BMI," +
                                             " \n \t\t  'm' - for multiply matrixes" +
                                             " \n \t'c' to clear last value" +
                                             " \t\t 'h' - display history" +
                                             " \t\t'q' to exit");

            if (input == null)
                input = Console.ReadLine();
            if (!ValidateInputs(input))
                throw new IncorrectInputException("There is no such function. Please try again.");
            return input;
        }


        public string MainMenuStart(string input = null)
        {
            var OperationType = new OperationTypes();
            if (input == null)
            {
                input = GetInputForOperations();
            }

            operationInput = input;
            Operation = OperationType.OperationType(input);

            return operationInput;
        }
        public void historyProgram(string input) => HistoryManager.PrintLog();
        
        public void clearLastResult(string input)
        {
            LastResult = 0;
            LastResultMatrix = null;
        }
        
    }

   
    public class MatchNumumericalMenu : Menu
        {
        public double GetOperandDouble(string input)
        {
            double doubleValue;
            Console.WriteLine(input);
            while (!double.TryParse(input, out doubleValue))
            {
              input =  IoManager.ReadOperand("Input must be double number !");
            }
            return doubleValue;
        }
        
        public void SetOperands(Operations operation, double FirstArgument, double SecondArgument)
        {
                operation.Operand1 = FirstArgument;
                operation.Operand2 = SecondArgument;
        }
        public void SetInputsForBMI(Operations operation, double weight, double height)
        {
            operation.Operand1 = weight;
            operation.Operand2 = height;
        }
    }
    public class MathMatrixRunnerMenu : Menu
    {
        public int GetOperandInt(string input)
        {
            int intValue;
            Console.WriteLine(input);
            while (!int.TryParse(input, out intValue))
            {
                input = IoManager.ReadOperand("Input must be double number !");
            }
            return intValue;
        }

        public int[,] FillMatrix(int x, int y)
        {
            int[,] A = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write($"[" + i + "," + j + "]: ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return A;
        }
        public class MatrixCl
        {
            public int row { get; set; }
            public int column { get; set; }
            public int[,] matrix { get; set; }
        }

        public int[,] SetLengthM1(int[,] input = null)
        {
            var M1 = new MatrixCl();
            if (input == null)
            {
                M1.row = GetOperandInt(rowMsg);
                M1.column = GetOperandInt(columnMsg);
                M1.matrix = new int[M1.row, M1.column];
                M1.matrix = FillMatrix(M1.row, M1.column);
            }
            else
                M1.matrix = input;
            return M1.matrix;
        }
        public int[,] SetLengthM2(int[,] input1, int[,] input2 = null)
        {
            var M2 = new MatrixCl();
            if (input2 == null)
            {
                M2.row = GetOperandInt(rowMsg);
                while (input1.GetLength(1) != M2.row)
                {
                    Console.WriteLine("collumns 1Matrix must be = rows 2Matrix");
                    M2.row = GetOperandInt(rowMsg);
                }
                M2.column = GetOperandInt(columnMsg);
                M2.matrix = new int[M2.row, M2.column];
                M2.matrix = FillMatrix(M2.row, M2.column);
            }
            return M2.matrix;
        }
        public void SetInputsForMartix(Operations operation, int[,] M1, int[,] M2)
        {
            operation.Matrix1 = M1;
            operation.Matrix2 = M2;
        }
        public int[,] SetInputM1(bool loop, int[,] M1 = null, int[,] resultmatrix = null)
        {
                M1 = loop? SetLengthM1(M1) : resultmatrix;
            return M1;
        }
    }
}
