﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace CalculatorO.Tests
{
    [TestFixture]

    class BMITests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;

        [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
        }
        
        [Test]
        public void BMITest()
        {
            Operations operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();
            Assert.AreEqual(19.03, operation.Result);
        }

        [Test]

        public void BMIHistoryTest()
        {
            Operations operation = new BMI();
            operation.Operand1 = 55;
            operation.Operand2 = 1.70;
            operation.Calculate();

            operation.SaveDisplayRes();

            Assert.AreEqual("BMI result : 55 / (1.7*2) = 19.03 \t It's Normal weight ", operation.calculation);
        }
       

        [Test, TestCaseSource("BMIConsequenceTest")]
        public void BMIConsequencesTest(string actual, string expected)

        {
            Operations operation = new BMI();
            Assert.AreEqual(expected, operation.BMIConsequence(Convert.ToDouble(actual)));
        }

        static object[] BMIConsequenceTest = new object[]
        {
            new string[] { "18.5", "Underweight"},
            new string[] { "25", "Normal weight"},
            new string[] { "26.01", "Overweight"},
            new string[] { "30", "Overweight"},
            new string[] { "30.01", "Obese"},

        };
    }
}
