﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    
    class BMITests
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        HistoryManager historyManager;

        [SetUp]
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

            Assert.AreEqual("BMI result : 55 / (1.7*2) = 19.03 \t It's Normal weight ", 
                operation.calculation);
        }
       
        /*
        [Test]
        public void BMIConsequenceTest()
        {
            BaseOperation operation = new BMI();
            string a = operation.BMIConsequence(20.0);
            
            Assert.AreEqual("Normal weight", a);

        }
        */
        
        [Test, TestCaseSource("BMIConsequenceTest")]
        public void BMIConsequencesTest(string res, string expected)
        {
            BaseOperation operation = new BMI();
            Assert.AreEqual(expected, operation.BMIConsequence(Convert.ToDouble(res)));
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

        //bad, how i can check inputs
        [Test]
        public void ValidateInputsOutputsforBMI()
        {
            
            double a = mathRunnerMenu.GetOperand("7.14");
            Assert.AreEqual(a, mathRunnerMenu.GetOperand("7.14"));
        }

        //compare history val with added ?????
        [Test]
        public void GetBMIvalueFromHistory()
        {
            BaseOperation operation = new BMI();
            BMITest();
            historyManager.AddLog(operation.calculation);
             historyManager.PrintLog();
            Assert.Equals("BMI result: 55 / (1.7 * 2) = 19.03 \t It's Normal weight ", );
        }


    }
}
