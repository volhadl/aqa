using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO.Tests
{
    
    [TestFixture]
    class BaseOperationsTests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
        }
        
        //check that label that correct we get correct match op

        [Test]
        public void ValidateLabel()
        {
            Operations operation = new Multiply();
            string expected = "*";

            Assert.AreEqual(expected, operation.Label);
        }
        [Test]
        public void ValidateLabelNeg()
        {
            Operations operation = new Multiply();
            string expected = "+";

            Assert.AreNotEqual(expected, operation.Label);

        }
        
    }
}

