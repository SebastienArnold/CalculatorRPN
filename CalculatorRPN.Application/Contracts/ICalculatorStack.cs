using CalculatorRPN.Application.Domain;
using System.Collections.Generic;

namespace CalculatorRPN.Application.Contracts
{
    public interface ICalculatorStack
    {
        IEnumerable<double> GetStack { get; }
        int StackSize { get; }
        void AddValue(double value);
        void Compute(OperatorEnum operation);
        void Clear();
    }
}