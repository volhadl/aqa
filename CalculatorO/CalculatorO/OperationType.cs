using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO
{
    class OperationTypes
    {
        public Operations OperationType(string input)
        {
            Operations resultOperation = null;
            switch (input)
            {
                case "+":
                    resultOperation = new Add();
                    break;
                case "-":
                    resultOperation = new Subtract();
                    break;
                case "*":
                    resultOperation = new Multiply();
                    break;
                case "/":
                    resultOperation = new Divide();
                    break;
                case "b":
                    resultOperation = new BMI();
                    break;
                case "m":
                    resultOperation = new MatrixMultiply();
                    break;
            }
            return resultOperation;
        }
    }
}
