using CalculatorRPN.Application.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorRPN.Application.UnitTests
{
    [TestClass]
    public class GivenAnEmptyStackWhenValueIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
        }

        protected override void When()
        {
            calculatorStack.AddValue(10);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }
    }

    [TestClass]
    public class GivenAnEmptyStackWhenValueIsAddedTwice : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
        }

        protected override void When()
        {
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(3);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(2, calculatorStack.StackSize);
        }
    }

    [TestClass]
    public class GivenAStackContainingTwoValuesWhenSumOperationIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(3);
        }

        protected override void When()
        {
            calculatorStack.Compute(OperatorEnum.Sum);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }

        [TestMethod]
        public void ThenStackValueIsTheSumResult()
        {
            var enumerator = calculatorStack.GetStack.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            Assert.AreEqual(13, result);
        }
    }

    [TestClass]
    public class GivenAStackContainingTwoValuesWhenSubstractOperationIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(3);
        }

        protected override void When()
        {
            calculatorStack.Compute(OperatorEnum.Substract);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }

        [TestMethod]
        public void ThenStackValueIsTheSumResult()
        {
            var enumerator = calculatorStack.GetStack.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            Assert.AreEqual(7, result);
        }
    }

    [TestClass]
    public class GivenAStackContainingTwoValuesWhenMultiplyOperationIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(3);
        }

        protected override void When()
        {
            calculatorStack.Compute(OperatorEnum.Multiply);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }

        [TestMethod]
        public void ThenStackValueIsTheSumResult()
        {
            var enumerator = calculatorStack.GetStack.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            Assert.AreEqual(30, result);
        }
    }

    [TestClass]
    public class GivenAStackContainingTwoValuesWhenDivideOperationIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(5);
        }

        protected override void When()
        {
            calculatorStack.Compute(OperatorEnum.Divide);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }

        [TestMethod]
        public void ThenStackValueIsTheSumResult()
        {
            var enumerator = calculatorStack.GetStack.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            Assert.AreEqual(2, result);
        }
    }

    [TestClass]
    public class GivenAStackRequestingADivisionByZeroWhenDivideOperationIsAdded : GivenWhenThen
    {
        private CalculatorStack calculatorStack = null;

        protected override void Given()
        {
            calculatorStack = new CalculatorStack();
            calculatorStack.AddValue(10);
            calculatorStack.AddValue(0);
        }

        protected override void When()
        {
            calculatorStack.Compute(OperatorEnum.Divide);
        }

        [TestMethod]
        public void ThenStackContainOneElement()
        {
            Assert.AreEqual(1, calculatorStack.StackSize);
        }

        [TestMethod]
        public void ThenStackValueIsTheSumResult()
        {
            var enumerator = calculatorStack.GetStack.GetEnumerator();
            enumerator.Reset();
            enumerator.MoveNext();
            var result = enumerator.Current;

            Assert.AreEqual(double.PositiveInfinity, result);
        }
    }
}
