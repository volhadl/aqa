using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Calculator_2._0.Tests
{
    [TestFixture]
    
    class BMITests
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        HistoryManager historyManager;

        [OneTimeSetUp]
            public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
            historyManager = new HistoryManager();
            
        }

    [Test]
        public void BMITest()
        {
            BaseOperation operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            Assert.AreEqual(19.03, operation.Result );

        }

        [Test]
       
        public void BMIHistoryTest()
        {
            BaseOperation operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();

            operation.DisplayRes();

            Assert.AreEqual("BMI result : 55 / (1.7*2) = 19.03 \t It's Normal weight ", operation.calculation);
        }
        //double[] BMIValidInputs = new double[] { 55, 1.70, 19.03,  };


        /*
        [Test]
        public void BMIConsequenceTest()
        {
            BaseOperation operation = new BMI();
            string a = operation.BMIConsequence(20.0);
            
            Assert.AreEqual("Normal weight", a);

        }
        */
        /*
        [Test, TestCaseSource("ValidInputsAndOutputs")]
        public void ValidateInputsAndOutputs(string expected, string actual)
        {
            Assert.AreEqual(expected, mainMenu.GetInputForOperation(actual));
        }

        static object[] ValidInputsAndOutputs = new object[]
        {
            new string[] {"+", "+"},
            new string[] {"-", "-"},
            new string[] {"*", "*"},
            new string[] {"/", "/"}
        };*/

        [Test, TestCaseSource("BMIConsequenceTest")]
        public void BMIConsequencesTest(string expected, string actual)
        {
            BaseOperation operation = new BMI();

            Assert.AreEqual(expected, operation.BMIConsequence());
        }

        static object[] BMIConsequenceTest = new object[]
        {
            new string[] { "18.5", "Underweight"},
            new string[] { "18.51", "Normal weight"},
            new string[] { "25", "Normal weight"},
            new string[] { "26.01", "Overweight"},
            new string[] { "30", "Overweight"},
            new string[] { "30.01", "Obese"},

        };

    }
}
