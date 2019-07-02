using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Calculator_2._0.Tests
{
    [TestFixture]
    class MatchOperations
    {
        MainMenu mainMenu;
        MathRunnerMenu mathRunnerMenu;
        

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MathRunnerMenu();
            
        }

        [Test]
        public void DivideTest()
        {
            BaseOperation operation = new Divide();
            operation.Operand1 = 3;
          
            try
            {
                operation.Operand2 = 0;
                operation.Calculate();
                Assert.Fail();
            }
            catch (NullReferenceException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("You cannot devide on 0"));
            }
        }

        //Look! Why NUNIT use such long method it example
        [Test]
        public void DivideTestNullException()
        {
            BaseOperation operation = new Divide();
            operation.Operand1 = 3;
            try
            {
                operation.Operand2 = 0;
                operation.Calculate();
            }
            catch
            {
                NullReferenceException ex = Assert.Throws<NullReferenceException>(
                delegate { throw new NullReferenceException("You cannot devide on 0"); });
                Assert.That(ex.Message, Is.EqualTo("You cannot devide on 0"));
            }
        }

      

        [Test]
        public void MatchOpHistoryTest()
        {
            BaseOperation operation = new Add();
            operation.Operand1 = 5;
            operation.Operand2 = 2;
            operation.Calculate();
            operation.DisplayRes();

            Assert.AreEqual("Mathematical result : 5 + 2 = 7",
                operation.calculation);
        }


        [Test, TestCaseSource(nameof(MySourceMethod))]
        public void OperationsTest(Dictionary<double, BaseOperation> dict)
        {
            var key = dict.Keys.ToList().ElementAt(0);
            dict.TryGetValue(key, out BaseOperation operation);
            operation.Calculate();
            Assert.AreEqual(key, operation.Result);

        }

        static IEnumerable<TestCaseData> MySourceMethod
        {
            get
            {
                yield return new TestCaseData
                    (
                    new Dictionary<double, BaseOperation>()
                    {
                        { 11,
                            new Add()
                            {
                                Operand1 = 5,
                                Operand2 = 6
                            }

                        }
                    }
                    );

                yield return new TestCaseData
                    (
                    new Dictionary<double, BaseOperation>()
                    {
                        { -1,
                            new Subtract()
                            {
                                Operand1 = 5,
                                Operand2 = 6
                            }

                        }
                    }
                    );
                yield return new TestCaseData
                    (
                    new Dictionary<double, BaseOperation>()
                    {
                        { 10,
                            new Multiply()
                            {
                                Operand1 = 5,
                                Operand2 = 2
                            }

                        }
                    }
                    );
                yield return new TestCaseData
                    (
                    new Dictionary<double, BaseOperation>()
                    {
                        { 5,
                            new Divide()
                            {
                                Operand1 = 10,
                                Operand2 = 2
                            }

                        }
                    }
                    );
            }
        }

    }
}
