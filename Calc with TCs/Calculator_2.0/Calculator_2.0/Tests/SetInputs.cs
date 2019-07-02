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


        //bad, how i can check inputs 
        
        [Test]
        public void ValidateGetOperandMethod()
        {
            var a = mathRunnerMenu.GetOperand("7.14");
            bool outputType = a.GetType() == typeof(double);
            Assert.AreEqual(true, outputType);
        }
        
    }
}
