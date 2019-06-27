using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Calculator_2._0.Tests
{
    

    
    [TestFixture]
    class CalculatorTestFirst
    {
        MainMenu mainMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
        }

        /*
        [Test]
        public void ValidateInputsTest() //check inputs ftom menu
        {
            Assert.True(mainMenu.ValidateInputs("q"), $" q is a valid input");
        }
        */
    
        //[Test, TestCase("+"), TestCase("-"), TestCase("*")]
        //public void ValidateInputsTest(string input) => Assert.True(mainMenu.ValidateInputs(input), $"{input} is not a valid input");
        
        
    
        [Test, TestCaseSource("MainMenuValidInputs")]
        public void ValidateValidInputsTest(string input) //check inputs ftom menu
        {
            Assert.True(mainMenu.ValidateInputs(input), $"{input} is a valid input");
        }

        [Test, TestCaseSource("MainMenuInValidInputs")]
        public void ValidateInValidInputsTest(string input) //check inputs ftom menu
        {
            Assert.False(mainMenu.ValidateInputs(input), $"{input} is not a valid input");
        }

        static string[] MainMenuValidInputs = new string[] { "+", "-", "*", "/", "b", "m", "h", "c", "q", "B", "M", "H", "C", "Q" };
        static string[] MainMenuInValidInputs = new string[] { "0", "1", "5", "8", "9", "-1", "n", "x", "v" };

        [Test, TestCaseSource("ValidInputsAndOutputs") ]
        public void ValidateInputsAndOutputs(string expected, string actual) 
        {
            Assert.AreEqual(expected, mainMenu.GetInputForOperation(actual));
        }

        static object[]ValidInputsAndOutputs = new object[]
        {
            new string[] {"+", "+"},
            new string[] {"-", "-"},
            new string[] {"*", "*"},
            new string[] {"/", "/"}
        };

        [Test, TestCaseSource("ExitValidInputs")]
        public void QuiteTest(string expected) => Assert.Throws<ExitException>(() => mainMenu.GetInputForOperation(expected));
        static string[] ExitValidInputs = new string[] { "q", "Q" };


        [Test]
        public void AdditionalTest(double expected, BaseOperation operation)
        {
            operation.Calculate();
            Assert.AreEqual(expected, operation.Result); 
        }//как добавить коллекцию в юнит

        static IDictionary<double, BaseOperation> Operations = new Dictionary<double, BaseOperation>()
        {

            {11, new Add()
            {
                Operand1 = 5,
                Operand2 = 6
            } },
            {-1, new Subtract()
            {
                Operand1 = 2,
                Operand2 = 3
            } }
        };
    }
}
