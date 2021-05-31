using CalculatorRPN.Application.Contracts;
using System;
using System.Collections.Generic;

namespace CalculatorRPN.Application.Domain
{
    public enum OperatorEnum
    {
        Sum,
        Substract,
        Multiply,
        Divide
    }

    public class CalculatorStack : ICalculatorStack
    {
        private Stack<double> computeStack = new Stack<double>();

        private const int MaximumStackSize = 10000;

        public void AddValue(double value)
        {
            if(StackSize == MaximumStackSize)
            {
                throw new System.StackOverflowException("Calculation stack reach his maximum size.");
            }

            computeStack.Push(value);
        }

        public void Compute(OperatorEnum operation)
        {
            if(StackSize<2)
            {
                throw new InvalidOperationException("Stack need two values to be able to operate.");
            }

            switch (operation)
            {
                case OperatorEnum.Sum:
                    var sum = computeStack.Pop() + computeStack.Pop();
                    computeStack.Push(sum);
                    break;
                case OperatorEnum.Substract:
                    var lastValueForDiff = computeStack.Pop();
                    var result = computeStack.Pop() - lastValueForDiff;
                    computeStack.Push(result);
                    break;
                case OperatorEnum.Multiply:
                    var product = computeStack.Pop() * computeStack.Pop();
                    computeStack.Push(product);
                    break;
                case OperatorEnum.Divide:
                    var lastValueForQuotient = computeStack.Pop();
                    var quotient = computeStack.Pop() / lastValueForQuotient;
                    computeStack.Push(quotient);
                    break;
            }
        }

        public int StackSize
        {
            get
            {
                return computeStack.Count;
            }
        }

        public IEnumerable<double> GetStack
        {
            get
            {
                return computeStack;
            }
        }

        public void Clear()
        {
            computeStack.Clear();
        }
    }
}
