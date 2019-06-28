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
        public void QuiteTest(string expected) => Assert.Throws<ExitException>(() => mainMenu.GetInputForOperation(expected));
        static string[] QuiteValidateInputs = new string[] { "q", "Q" };


        [Test, TestCaseSource("ClearValidateInputs")]
        public void ClearTest(string expected) => Assert.Throws<ClearMemoryException>(() => mainMenu.GetInputForOperation(expected));
        static string[] ClearValidateInputs = new string[] { "c", "C" };


        [Test, TestCaseSource("HistoryValidateInputs")]
        public void HistoryTest(string expected) => Assert.Throws<HistoryException>(() => mainMenu.GetInputForOperation(expected));
        static string[] HistoryValidateInputs = new string[] { "h", "H" };

       


    }
}
