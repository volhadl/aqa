using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class GetInputForOperationTest
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
        }

        [Test, TestCaseSource("QuiteValidateInputs")]
        public void QuiteTest(string expected) => Assert.Throws<ExitException>(() 
            => mainMenu.GetInputForOperation(expected));
        static string[] QuiteValidateInputs = new string[] { "q", "Q" };


        [Test, TestCaseSource("ClearValidateInputs")]
        public void ClearTest(string expected) => Assert.Throws<ClearMemoryException>(() 
            => mainMenu.GetInputForOperation(expected));
        static string[] ClearValidateInputs = new string[] { "c", "C" };


        [Test, TestCaseSource("HistoryValidateInputs")]
        public void HistoryTest(string expected) => Assert.Throws<HistoryException>(() 
            => mainMenu.GetInputForOperation(expected));
        static string[] HistoryValidateInputs = new string[] { "h", "H" };


        [Test, TestCaseSource("ExceptionInValidInputs")]
        public void ValidateExceptionMessage(string expected)
        {
            try
            {
                mainMenu.GetInputForOperation(expected);
                Assert.Fail();
            }
            catch (InvalidInputException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("There is no such function. Please try again."));
            }
            
        }
        static string[] ExceptionInValidInputs = new string[] { "0", "1", "5", "8", "9", "-1", "n", "x", "v" };


        [Test]
        public void ExitException()
        {

            try
            {
                mainMenu.GetInputForOperation("q");
            }
            catch (ExitException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("See you next time..."));
            }
            
        }


        //last value is available to clean
        //Operand1 get result
        [Test]
        public void ValidateClear()
        {
            /*
            BaseOperation operation = new Add();
            operation.Operand1 = 2;
            operation.Operand2 = 3;
            operation.Calculate();
            mainMenu.GetInputForOperation("+");
            mainMenu.UseLastValue = true;
            mathRunnerMenu.LastResult = operation.Result;
            mathRunnerMenu.SetInputsForMathOperation(operation);
            */
            mathRunnerMenu.input_1 = 2;
            mathRunnerMenu.input_2 = 3;



            Assert.AreEqual(5, operation.Operand1);

        }

    }
}
