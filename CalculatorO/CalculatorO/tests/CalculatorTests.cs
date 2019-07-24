using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO.tests
{

    [TestFixture]
    class CalculatorTests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;
        MathMatrixRunnerMenu matrixRunnerMenu;
        Calculator calculator;

        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
            matrixRunnerMenu = new MathMatrixRunnerMenu();
            calculator = new Calculator();
        }
        /*
        [Test]
        public void ValidateCalc()
        {
            calculator.start("+");

            Assert.AreEqual("+", mainMenu.Operation.Label);
        }*/

    }
}
