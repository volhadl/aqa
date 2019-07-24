using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculatorO.Tests
{
    [TestFixture]
    class HistoryTests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;
        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
        }
        [Test]
        public void ValidateExceptionMessageEmptyHistory()
        {
            RemoveAllItemsFromList();
            try
            {
                mainMenu.MainMenuStart("h");
                mainMenu.historyProgram(mainMenu.operationInput);
                Assert.Fail();
            }
            catch (EmptyHistoryException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("List is either null or empty"));
            }
        }
        public void RemoveAllItemsFromList()
        {
            HistoryManager.history.Clear();
        }

        [Test]
        public void GetBMIvalueFromHistory()
        {
            RemoveAllItemsFromList();
            Operations operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            operation.SaveDisplayRes();
            HistoryManager.AddLog(operation.calculation);
            string[] expected = new string[] { "BMI result : 55 / (1.7*2) = 19.03 	 It's Normal weight " };
            Assert.That(expected, Is.EquivalentTo(HistoryManager.history));
        }
       
        [Test]
        public void GetMatchOpvalueFromHistory()
        {
            RemoveAllItemsFromList();
            Operations operation = new Add();
            operation.Operand1 = 5;
            operation.Operand2 = 2;
            operation.Calculate();
            operation.SaveDisplayRes();

            HistoryManager.AddLog(operation.calculation);
            var actual = HistoryManager.history.ElementAt(0);
            var expected = "Mathematical result : 5 + 2 = 7";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GetMatrixValueFromHistory()
        {
            RemoveAllItemsFromList();
            Operations operation = new MatrixMultiply();
            operation.Matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            operation.Matrix2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            operation.Calculate();
            operation.SaveDisplayRes();
            HistoryManager.AddLog(operation.calculation);
            var actual = HistoryManager.history.ElementAt(0);
            var expected = "matrix multiplication result : {1,2,3},{4,5,6},{7,8,9} * {1,2},{3,4},{5,6} = {22,28},{49,64},{76,100}";
            Assert.AreEqual(expected, actual);
        }
    }
}
