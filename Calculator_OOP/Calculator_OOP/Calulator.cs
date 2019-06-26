using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_OOP
{
    class Calculator
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        HistoryManager historyManager;

        public Calculator()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
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
                    mathRunnerMenu.SetInputsForMathOperation(mainMenu.Operation);
                    mainMenu.Operation.Calculate();
                    var calculation = $"{mainMenu.Operation.A} {mainMenu.Operation.Label} {mainMenu.Operation.B} " +
                        $"= {mainMenu.Operation.Result} ";
                    historyManager.AddLog(calculation);
                    mathRunnerMenu.UseLastValue = true;
                    mathRunnerMenu.LastResult = mainMenu.Operation.Result;
                    Console.WriteLine(calculation);
                    historyManager.PrintLog();
                }
                catch (ExitException e)
                {
                    Console.WriteLine(e.Message);
                    exit = true;
                }
                catch (InvalidInputException e)
                { Console.WriteLine(e.Message); }
                catch (ClearMemoryException e)
                {
                    if (mainMenu.Operation != null)
                    {
                        mainMenu.Operation.Result = 0;
                        mathRunnerMenu.UseLastValue = false;
                    }
                       
                }
            }
        }


    }
}
