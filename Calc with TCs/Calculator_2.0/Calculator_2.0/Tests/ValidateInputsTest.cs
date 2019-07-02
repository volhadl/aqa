using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class ValidateInputsTest
    {
        MainMenu mainMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
        }

        [Test, TestCaseSource("MainMenuValidInputs")]
        public void ValidateValidInputsTest(string input) //check inputs from menu
        {
            Assert.True(mainMenu.ValidateInputs(input), $"{input} is a valid input");
        }
        static string[] MainMenuValidInputs = new string[] { "+", "-", "*", "/", "b", "m", "h", "c", "q", "B", "M", "H", "C", "Q" };


        [Test, TestCaseSource("MainMenuInValidInputs")]
        public void ValidateInValidInputsTest(string input) //check inputs from menu
        {
            Assert.False(mainMenu.ValidateInputs(input), $"{input} is not a valid input");
        }
        static string[] MainMenuInValidInputs = new string[] { "0", "1", "5", "8", "9", "-1", "n", "x", "v" };


    }
}
