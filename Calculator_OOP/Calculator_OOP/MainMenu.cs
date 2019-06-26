using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator_OOP
{
    public abstract class BaseMenu
    {
        public BaseOperation Operation { get; set; }
        public bool UseLastValue { get; set; }

        public double LastResult { get; set; }

        
        List<string> validInputs = new List<string>()
        {
            "+",
            "-",
            "*",
            "/",
            "c",
            "q"
        };
        protected bool ValidateInputs(string input) => validInputs.Any(i => i.Equals(input, StringComparison.InvariantCultureIgnoreCase));
        //StringComparison. представляет собой перечисление, 
        //явно задающее правила сравнения строк по языку, региональным параметрам и регистру.
        //InvariantCultureIgnoreCase - сравнение строк без учета регистра, используя правила сравнения 
        //строк по словам для инвариантного языка и региональных параметров.
        protected void quitProgram(string input)
        {
            if (input.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                throw new ExitException();
        }

        protected void clearLastResult(string input)
        {
            if (input.Equals("c", StringComparison.InvariantCultureIgnoreCase))
                throw new ClearMemoryException();
        }
    }


    public class MainMenu : BaseMenu
    {
        private string GetInputForOperation()
        {
            Console.WriteLine("Select operation: '+', '-', '*', '/', 'c' to clear or 'q' to exit");
            string input = Console.ReadLine();
            if (!ValidateInputs(input))
                throw new InvalidInputException();
            quitProgram(input);
            clearLastResult(input);
            return input.ToLower();
        }

        public void MainMenuStart()
        {
            var operationInput = GetInputForOperation();         
            Operation = OperationFactory(operationInput);
        }

        private BaseOperation OperationFactory(string operation)
        {
            BaseOperation resultOperation = null;
            switch (operation)
            {
                case ("+"):
                    resultOperation = new Addition();
                    break;
                case ("-"):
                    resultOperation = new Subtraction();
                    break;
                case ("*"):
                    resultOperation = new Multiplication();
                    break;
                case ("/"):
                    resultOperation = new Division();
                    break;
                default:
                    throw new InvalidInputException("Operation you entered is not recognized. Please, try again");
            }
            return resultOperation;
        }
    }

    public class MathRunnerMenu : BaseMenu
    {
        public void SetInputsForMathOperation(BaseOperation operation)
        {
            double input_1;
            double input_2;
            if (UseLastValue)
                operation.A = LastResult;
            else
            {
                try
                {
                    input_1 = GetOperand("Input 1st number: ");
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                    input_1 = GetOperand("Input 1st number: ");
                }
                operation.A = input_1;
            }       

            try
            {
                input_2 = GetOperand("Input 2nd number: ");
            }
            catch (InvalidInputException e)
            {
                Console.WriteLine(e.Message);
                input_2 = GetOperand("Input 2nd number: ");
            }
            operation.B = input_2;

        }

        private double GetOperand(string message)
        {
            bool exit = false;
            double operand = 0;
            while (!exit)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                quitProgram(input);
                if (!double.TryParse(input, out double a))
                    throw new InvalidInputException("Input must be double number");
                else
                {
                    exit = true;
                    operand = a;
                }
            }
            return operand;
        }
    }

    public class ExitException : Exception
    {
        public override string Message => "See you next time...";
    }

    public class ClearMemoryException : Exception
    { }

    public class InvalidInputException : Exception
    {
        public InvalidInputException()
        {
        }

        public InvalidInputException(string message) : base(message)
        {
        }

        public override string Message => "Input is not valid. Try again";
    }
}
