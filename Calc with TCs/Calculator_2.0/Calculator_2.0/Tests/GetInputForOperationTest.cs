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

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
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

    }
}
