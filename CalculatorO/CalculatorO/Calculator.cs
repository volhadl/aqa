using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO
{
    class Calculator
    {
        MainMenu mainMenu;
        MatchNumumericalMenu numRunnerMenu;
        MathMatrixRunnerMenu matrixRunnerMenu;

        private bool exit;
        public static string a = "first matrix = ";
        string b = "second matrix = ";
        public Calculator()
        {
            mainMenu = new MainMenu();
            numRunnerMenu = new MatchNumumericalMenu();
            matrixRunnerMenu = new MathMatrixRunnerMenu();
        }

        public void start(string input = null)
        {
            numRunnerMenu.isFirstLoop = true;
            exit = false;
            if (input == null)
            {
                while (!exit)
                {
                    try
                    {
                        mainMenu.MainMenuStart();
                        input = mainMenu.operationInput;
                        if (mainMenu.operationInput == "c")
                            mainMenu.clearLastResult(mainMenu.operationInput);
                        else if (mainMenu.operationInput == "h")
                            mainMenu.historyProgram(mainMenu.operationInput);
                        else if (mainMenu.operationInput == "q")
                            exit = true;
                        else if (mainMenu.operationInput == "b")
                        {
                            mainMenu.weight = numRunnerMenu.GetOperandDouble(mainMenu.weightMsg);
                            mainMenu.height = numRunnerMenu.GetOperandDouble(mainMenu.heightMsg);
                            numRunnerMenu.SetInputsForBMI(mainMenu.Operation, mainMenu.weight, mainMenu.height);
                            mainMenu.Operation.Calculate();
                            mainMenu.Operation.addToHistory(mainMenu.Operation.SaveDisplayRes());
                        }
                        else if (mainMenu.operationInput == "m")
                        {
                            matrixRunnerMenu.isFirstLoop = IoManager.Checker(mainMenu.LastResultMatrix);
                            mainMenu.Matrix1 = matrixRunnerMenu.SetInputM1(matrixRunnerMenu.isFirstLoop, matrixRunnerMenu.Matrix1, mainMenu.LastResultMatrix);
                            IoManager.WriteOperand(b);
                            mainMenu.Matrix2 = matrixRunnerMenu.SetLengthM2(mainMenu.Matrix1);
                            matrixRunnerMenu.SetInputsForMartix(mainMenu.Operation, mainMenu.Matrix1, mainMenu.Matrix2);
                            mainMenu.Operation.Calculate();
                            mainMenu.Operation.addToHistory(mainMenu.Operation.SaveDisplayRes());
                            mainMenu.LastResultMatrix = mainMenu.Operation.MatrixResult;
                        }
                        else
                        {
                            numRunnerMenu.isFirstLoop = IoManager.CheckerN(mainMenu.LastResult);
                            mainMenu.FirstArgument = numRunnerMenu.isFirstLoop ? numRunnerMenu.GetOperandDouble(mainMenu.firstMsg) : mainMenu.LastResult;
                            mainMenu.SecondArgument = numRunnerMenu.GetOperandDouble(mainMenu.secondMsg);
                            numRunnerMenu.SetOperands(mainMenu.Operation, mainMenu.FirstArgument, mainMenu.SecondArgument);
                            mainMenu.Operation.Calculate();
                            mainMenu.Operation.addToHistory(mainMenu.Operation.SaveDisplayRes());
                            mainMenu.LastResult = mainMenu.Operation.Result;
                        }
                    }
                    catch (IncorrectInputException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (EmptyHistoryException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}

                    