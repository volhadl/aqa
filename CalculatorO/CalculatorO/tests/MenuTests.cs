using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorO.tests
{
    [TestFixture]
    class MenuTests
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;
        MathMatrixRunnerMenu matrixRunnerMenu;

       [OneTimeSetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
            matrixRunnerMenu = new MathMatrixRunnerMenu();
        }
        
        [Test]
        public void GetInputType()
        {
            var a = mainMenu.GetInputForOperations("h");
            bool outputType = a.GetType() == typeof(string);
            Assert.AreEqual(true, outputType);
        }
        [Test]
        public void VerifyClearLastResult()
        {
            mainMenu.LastResult = 8;
            mainMenu.LastResultMatrix = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            mainMenu.clearLastResult("c");
            
            Assert.AreEqual(0, mainMenu.LastResult);
            Assert.AreEqual(null, mainMenu.LastResultMatrix);
        }
        
        [Test]
        public void ValidateGetOperandDoubleMethod()
        {
            var a = mathRunnerMenu.GetOperandDouble("7,14");
            bool outputType = a.GetType() == typeof(double);
            Assert.AreEqual(true, outputType);
        }
       
        [Test]
        public void ValidateSetOperandsMethod()
        {
            mainMenu.MainMenuStart("+");
            mainMenu.FirstArgument = 5;
            mainMenu.SecondArgument = 2;
                        
            mathRunnerMenu.SetOperands(mainMenu.Operation, mainMenu.FirstArgument, mainMenu.SecondArgument);
            string[] actual = new string[3] { mainMenu.Operation.Label, Convert.ToString(mainMenu.Operation.Operand1),
                Convert.ToString(mainMenu.Operation.Operand2)};
            string[] expected = new string[3] { "+", "5", "2" };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ValidateSetBMIMethod()
        {
            mainMenu.MainMenuStart("b");
            mainMenu.weight = 55;
            mainMenu.height = 1.7;

            mathRunnerMenu.SetInputsForBMI(mainMenu.Operation, mainMenu.weight, mainMenu.height);
            string[] actual = new string[3] { mainMenu.Operation.Label, Convert.ToString(mainMenu.Operation.Operand1),
                Convert.ToString(mainMenu.Operation.Operand2)};
            string[] expected = new string[3] { "b", "55", "1.7"};
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ValidateSetMatrixMethod()
        {
            mainMenu.MainMenuStart("m");
            mainMenu.Matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            mainMenu.Matrix2 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };

            matrixRunnerMenu.SetInputsForMartix(mainMenu.Operation, mainMenu.Matrix1, mainMenu.Matrix2);
            string[] actual = new string[3] { mainMenu.Operation.Label,
               IoManager.CreateString(mainMenu.Operation.Matrix1, "matrix 1 : "),
                IoManager.CreateString(mainMenu.Operation.Matrix2, "matrix 2 : ")};
            string[] expected = new string[3] {"m", "matrix 1 : {1,2,3},{4,5,6},{7,8,9}",
                "matrix 2 : {1,2},{3,4},{5,6}"};
            Assert.AreEqual(expected, actual);
        }
       
        [Test]
        public void ValidateGetOperandIntMethod()
        {
            var a = matrixRunnerMenu.GetOperandInt("7");
            bool outputType = a.GetType() == typeof(int);
            Assert.AreEqual(true, outputType);
        }

        [Test]
        public void ValidateSetLengthM1Method()
        {
            mainMenu.LastResultMatrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            mainMenu.Matrix1 = false ? matrixRunnerMenu.SetLengthM1() : mainMenu.LastResultMatrix;
            Assert.AreEqual(mainMenu.LastResultMatrix, mainMenu.Matrix1);
        }
        
        [Test, TestCaseSource("valuesfortest")]
        public void ValidateSetInputToM1(bool loop, int[,] actualMatrisentere, int[,] matrixLR, int[,] expected)
        {
            mainMenu.Matrix1 = matrixRunnerMenu.SetInputM1(loop, actualMatrisentere, matrixLR);
            Assert.AreEqual(expected, mainMenu.Matrix1);
        }
        public static int[,] m1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        public static int[,] lr = new int[,] { { 1, 3 }, { 4, 6 }, { 7, 9 } };
        static object[] valuesfortest =
        {
            new object[] { true, m1, lr, m1 },
             new object[] { false, m1, lr, lr }
        };
       

    }
}