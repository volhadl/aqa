using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO.tests
{ 
    [TestFixture]
    class ioManagerTests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;
        MathMatrixRunnerMenu matrixRunnerMenu;

        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
            matrixRunnerMenu = new MathMatrixRunnerMenu();
        }
      
       [Test, TestCaseSource("values")]
        public void ValidateMatrixCheckerMethod(int[,] actual, bool expected)
        {
            matrixRunnerMenu.isFirstLoop = IoManager.Checker(actual);

            Assert.AreEqual(expected, matrixRunnerMenu.isFirstLoop);
        }
        static int[,] matrixfortest = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
        static object[] values =
        {
            new object[] { matrixfortest, false },
            new object[] { null, true }
            
        };

    [Test, TestCaseSource("lastresultvalues")]
        public void ValidateCheckerNMethod(double actual, bool expected)
        {
            
            mathRunnerMenu.isFirstLoop = IoManager.CheckerN(actual);

            Assert.AreEqual(expected, mathRunnerMenu.isFirstLoop);
        }
        static object[] lastresultvalues =
        {
            new object[] { 12, false },
            new object[] { 3, false },
            new object[] { -3, false },
            new object[] { 1, false },
            new object[] { 0, true }
        };
    }
}
