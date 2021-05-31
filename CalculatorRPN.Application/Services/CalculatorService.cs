using CalculatorRPN.Application.Contracts;
using CalculatorRPN.Application.Domain;
using System.Collections.Generic;

namespace CalculatorRPN.Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private ICalculatorStack _calculatorStack;

        public CalculatorService(ICalculatorStack calculatorStack)
        {
            _calculatorStack = calculatorStack;
        }

        public void AddValue(double value)
        {
            _calculatorStack.AddValue(value);
        }

        public List<double> GetStack()
        {
            var valueList = new List<double>();
            foreach (var value in _calculatorStack.GetStack)
            {
                valueList.Add(value);
            }
            return valueList;
        }

        public void Sum()
        {
            _calculatorStack.Compute(OperatorEnum.Sum);
        }

        public void Substract()
        {
            _calculatorStack.Compute(OperatorEnum.Substract);
        }

        public void Multiply()
        {
            _calculatorStack.Compute(OperatorEnum.Multiply);
        }

        public void Divide()
        {
            _calculatorStack.Compute(OperatorEnum.Divide);
        }

        public void Clear()
        {
            _calculatorStack.Clear();
        }
    }
}
