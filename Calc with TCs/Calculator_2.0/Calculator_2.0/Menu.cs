using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_2._0
{
    public abstract class BaseMenu
    {
        public BaseOperation OperationSign { get; set; }
        public bool UseLastValue { get; set; }
        public double LastResult { get; set; }
        public double LastBMI { get; set; }
        public int[,] LastResultMatrix { get; set; }


        string[] Options = new string[9] { "+", "-", "*", "/", "b", "m", "h", "c", "q" };

        internal bool ValidateInputs(string input) => Options.Any(i => i.Equals(input, StringComparison.InvariantCultureIgnoreCase));

        public void clearLastResult(string input)
        {
            if (input.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                throw new ClearMemoryException();
        }
        public void quitProgram(string input)
        {
            if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                throw new ExitException();
        }
        public void historyProgram(string input)
        {
            if (input.Equals("h", StringComparison.InvariantCultureIgnoreCase))
                throw new HistoryException();
        }


    }

    public class MainMenu : BaseMenu
    {
        internal string GetInputForOperation(string input = null)
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
                throw new InvalidInputException("There is no such function. Please try again."); ;

            quitProgram(input);
            clearLastResult(input);
            historyProgram(input);
            return input.ToLower();
        }


        private BaseOperation OperationType(string operation)
        {
            BaseOperation resultOperation = null;
            switch (operation)
            {
                case ("+"):
                    resultOperation = new Add();
                    break;
                case ("-"):
                    resultOperation = new Subtract();
                    break;
                case ("*"):
                    resultOperation = new Multiply();
                    break;
                case ("/"):
                    resultOperation = new Divide();
                    break;
                case ("b"):
                    resultOperation = new BMI();
                    break;
                case ("m"):
                    resultOperation = new MatrixMultiply();
                    break;
            }
            return resultOperation;
        }

        public void MainMenuStart()
        {
            var operationInput = GetInputForOperation();
            OperationSign = OperationType(operationInput);
        }

    }


    public class MathRunnerMenu : BaseMenu
    {
       public double input_1;
        public double input_2;
        public void SetInputsForMathOperation(BaseOperation operation)
        {
            if (UseLastValue)
            {
                operation.Operand1 = LastResult;
            }
            else
            {
                input_1 = GetOperand("Input 1st number: ");
                operation.Operand1 = input_1;
            }
            input_2 = GetOperand("Input 2nd number: ");
            operation.Operand2 = input_2;
        }

        public void SetInputsForBMI(BaseOperation operation)
        {
            Console.WriteLine("Input YOUR weight in kg: ");
            string A = Console.ReadLine();
            double input_1 = GetOperand(A);
            operation.Operand1 = input_1;

            Console.WriteLine("Input YOUR height in kg: ");
             A = Console.ReadLine();
            double input_2 = GetOperand(A);
            operation.Operand2 = input_2;
        }


        public double GetOperand(string A)
        {

            double B;
            while (!double.TryParse(A, out B))
            {
                Console.Write("Input must be double number ! Try again ");
                A = Console.ReadLine();
            }
            return B;

        }
    }
    public class MathMatrixRunnerMenu : BaseMenu
    {

        public int GetOperandInt(string input)
        {
            int OperandInt;
            Console.WriteLine(input);
            string operand = Console.ReadLine();  //get new
            while (!int.TryParse(operand, out OperandInt))
            {
                Console.Write("Input must be double number !");
                Console.WriteLine(input);
                operand = Console.ReadLine();
            }
            return int.Parse(operand);

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


        class MatrixCl
        {
            public int row { get; set; }
            public int column { get; set; }
            public int[,] matrix { get; set; }
        }
        public void SetInputsForMatrixOperation(BaseOperation operation)
        {
            var M2 = new MatrixCl();
            var M1 = new MatrixCl();

            if (UseLastValue)
            {
                operation.Matrix1 = LastResultMatrix;
            }
            else
            {
                M1.row = GetOperandInt(" row matrix 1 ");
                M1.column = GetOperandInt(" column matrix 1  ");

                M1.matrix = new int[M1.row, M1.column];
                M1.matrix = FillMatrix(M1.row, M1.column);
                operation.Matrix1 = M1.matrix;
            }
            M2.row = GetOperandInt(" row matrix 2 ");
            while (operation.Matrix1.GetLength(1) != M2.row)
            {
                Console.WriteLine("collumns 1Matrix must be = rows 2Matrix");
                M2.row = GetOperandInt(" row matrix 2 ");
            }
            M2.column = GetOperandInt(" column matrix 2  ");

            M2.matrix = new int[M2.row, M2.column];
            M2.matrix = FillMatrix(M2.row, M2.column);
            operation.Matrix2 = M2.matrix;
        }

    }


    public class ExitException : Exception
    {
        public override string Message => "See you next time...";
    }

    public class ClearMemoryException : Exception
    {

    }
    public class HistoryException : Exception
    {

    }

    public class InvalidInputException : Exception
    {


        public InvalidInputException(string message) : base(message)
        {
        }


    }

}