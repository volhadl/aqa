using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2._0.Tests
{
    [TestFixture]
    class MtrixTests
    {
        MainMenu mainMenu;

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
        }

        [Test]
        public void MatrixMultiplicationTest()
        {
            BaseOperation operation = new MatrixMultiply();
            operation.Matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            operation.Matrix2 = new int[,] { { 1, 2 }, { 3, 4 }, {5, 6 }};
            operation.Calculate();
            Assert.AreEqual(new int[,] { { 22, 28}, { 49,  64}, { 76,  100} }, operation.MatrixResult);

        }
    }
}
