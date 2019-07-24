using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CalculatorO.Tests
{
    [TestFixture]
    class MatchOperations
    {
        MainMenu mainMenu;
        MatchNumumericalMenu mathRunnerMenu;
        

        [SetUp]
        public void SetUp()
        {
            mainMenu = new MainMenu();
            mathRunnerMenu = new MatchNumumericalMenu();
        }

        [Test]
        public void DivideTest()
        {
            Operations operation = new Divide();
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

        //or
        [Test]
        public void DivideTestNullException()
        {
            Operations operation = new Divide();
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

      

       
        [Test, TestCaseSource(nameof(MySourceMethod))]
        public void OperationsTest(Dictionary<double, Operations> dict)
        {
            var key = dict.Keys.ToList().ElementAt(0);
            dict.TryGetValue(key, out Operations operation);
            operation.Calculate();
            Assert.AreEqual(key, operation.Result);
        }
        static IEnumerable<TestCaseData> MySourceMethod
        {
            get
            {
                yield return new TestCaseData
                    (
                    new Dictionary<double, Operations>()
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
                    new Dictionary<double, Operations>()
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
                    new Dictionary<double, Operations>()
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
                    new Dictionary<double, Operations>()
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
