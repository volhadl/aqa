using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class BMITests
    {
        MainMenu mainMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
        }

        [Test]
        public void BMITest()
        {
            BaseOperation operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            Assert.AreEqual(19.03, operation.Result);

        }

        [Test]
        public void BMIHistoryTest()
        {
            BaseOperation operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            operation.DisplayRes();

            Assert.AreEqual("BMI result : 55 / (1,7*2) = 19,03 \t It's Normal weight ", 
                operation.calculation);
        }
        
        [Test]
        public void BMIConsequenceTest()
        {
            BaseOperation operation = new BMI();
            string a = operation.BMIConsequence(20.0);
            
            Assert.AreEqual("Normal weight", a);

        }
        
        /*
        [Test, TestCaseSource("ValidInputsAndOutputs")]
        public void BMIConsequenceTestSec(double res, string expected)
        {
            BaseOperation operation = new BMI();
            string b = operation.BMIConsequence(res);
            Assert.AreEqual(expected, b);
        }

        static object[] ValidInputsAndOutputs = new object[]
        {
            new string[] {"19,03", "It's Normal weight"},
            
        };*/
    }
}
