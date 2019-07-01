using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;


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

        

        [Test]
        public void AddTest()
        {
            BaseOperation operation = new Add();
            operation.Operand1 = 1;
            operation.Operand2 = 5;
            operation.Calculate();
            Assert.AreEqual(6, operation.Result);

        }

        
        [Test, TestCaseSource("OutputOperationsTest")]

        public void OperationsTest(double expected, BaseOperation operation)
        {
            
            operation.Calculate();
            
            Assert.AreEqual(expected,  operation.Result);

        }//как добавить коллекцию в юнит

       

        static IDictionary<double, BaseOperation> OutputOperationsTest = new Dictionary<double, BaseOperation>()
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
