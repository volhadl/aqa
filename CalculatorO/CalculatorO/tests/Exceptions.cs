using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO.tests
{
    [TestFixture]

    class Exceptions
    {
        MainMenu mainMenu;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
        }
        [Test, TestCaseSource("ExceptionInValidInputs")]
        public void ValidateExceptionMessageIncorrectInput(string expected)
        {
            try
            {
                mainMenu.GetInputForOperations(expected);
                Assert.Fail();
            }
            catch (IncorrectInputException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("There is no such function. Please try again."));
            }

        }
        static string[] ExceptionInValidInputs = new string[] { "0", "1", "5", "8", "9", "-1", "n", "x", "v" };

       
    }
}