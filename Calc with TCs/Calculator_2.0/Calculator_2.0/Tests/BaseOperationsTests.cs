using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    
    [TestFixture]
    class BaseOperationsTests
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
        }
        
        //check that label that correct we get correct match op

        [Test]
        public void ValidateLabel()
        {
            BaseOperation operation = new Multiply();
            string expected = "*";

            Assert.AreEqual(expected, operation.Label);
        }
        [Test]
        public void ValidateLabelNeg()
        {
            BaseOperation operation = new Multiply();
            string expected = "+";

            Assert.AreNotEqual(expected, operation.Label);

        }
        
    }
}

