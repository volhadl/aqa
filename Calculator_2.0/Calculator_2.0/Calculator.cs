using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Calculator_2._0
{
    class Calculator
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        MathMatrixRunnerMenu mathMatrixRunnerMenu;
        HistoryManager historyManager;


        public Calculator()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
            mathMatrixRunnerMenu = new MathMatrixRunnerMenu();
            historyManager = new HistoryManager();
        }

        public void start()
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    mainMenu.MainMenuStart();

                    if (mainMenu.OperationSign.Label == "b")
                    {
                        mathRunnerMenu.SetInputsForBMI(mainMenu.OperationSign);
                        mainMenu.OperationSign.Calculate();
                        mainMenu.OperationSign.DisplayRes();
                        
                    }
                    else if (mainMenu.OperationSign.Label == "m")
                    {
                        mathMatrixRunnerMenu.SetInputsForMatrixOperation(mainMenu.OperationSign);
                        mainMenu.OperationSign.Calculate();
                        mainMenu.OperationSign.DisplayRes();
                        mathMatrixRunnerMenu.UseLastValue = true;
                        mathMatrixRunnerMenu.LastResultMatrix = mainMenu.OperationSign.MatrixResult;
                    }
                    else
                    {
                        mathRunnerMenu.SetInputsForMathOperation(mainMenu.OperationSign);
                        mainMenu.OperationSign.Calculate();
                        mainMenu.OperationSign.DisplayRes();
                        mathRunnerMenu.UseLastValue = true;
                        mathRunnerMenu.LastResult = mainMenu.OperationSign.Result;

                    }
                    
                    historyManager.AddLog(mainMenu.OperationSign.calculation);

                }
                catch (ExitException e)
                {
                    Console.WriteLine(e.Message);
                    exit = true;
                }
                catch (InvalidInputException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ClearMemoryException )
                {

                    if (mainMenu.OperationSign != null)
                    {
                        mainMenu.OperationSign.Result = 0;
                        mathRunnerMenu.UseLastValue = false;
                        mathMatrixRunnerMenu.UseLastValue = false;
                    }

                }
                catch (HistoryException )
                {
                  historyManager.PrintLog();
                   
                }
            }
        }
    }
}


