﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class HistoryTests
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        HistoryManager historyManager;

        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
            historyManager = new HistoryManager();

        }


        //compare history values with added 

        [Test]
        public void GetBMIvalueFromHistory()
        {
            BaseOperation operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            operation.DisplayRes();

            historyManager.AddLog(operation.calculation);
            var actual = historyManager.history.ElementAt(0);
            var expected = "BMI result : 55 / (1.7*2) = 19.03 \t It's Normal weight ";
            Assert.AreEqual(expected, actual);
            
        }
       


        [Test]
        public void GetMatchOpvalueFromHistory()
        {
            BaseOperation operation = new Add();
            operation.Operand1 = 5;
            operation.Operand2 = 2;
            operation.Calculate();
            operation.DisplayRes();

            historyManager.AddLog(operation.calculation);
            var actual = historyManager.history.ElementAt(1);
            var expected = "Mathematical result : 5 + 2 = 7";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMatrixValueFromHistory()
        {
            BaseOperation operation = new MatrixMultiply();
            operation.Matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            operation.Matrix2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            operation.Calculate();
            operation.DisplayRes();
            

            historyManager.AddLog(operation.calculation);
            var actual = historyManager.history.ElementAt(2);
            var expected = "matrix multiplication result : {1,2,3},{4,5,6},{7,8,9} * {1,2},{3,4},{5,6} = {22,28},{49,64},{76,100}";
            Assert.AreEqual(expected, actual);
        }

    }
}
