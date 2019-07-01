using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class SetInputs
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
        }


        //bad, how i can check inputs :(
        
        [Test]
        public void ValidateInputsOutputsforBMI()
        {

            double a = mathRunnerMenu.GetOperand("7.14");
            Assert.AreEqual(7.14, a);
        }
        /*
        [Test, TestCaseSource("ValidateInputsOutputsforBMI")]
        public void InputsOutputsforBMI(string expected) => mathRunnerMenu.GetOperand(expected);
        static string[] ValidateInputsOutputsforBMI = new string[] { "nngfn", "2" };*/
    }
}
