using System.Collections.Generic;

namespace CalculatorRPN.Application.Contracts
{
    public interface ICalculatorService
    {
        void AddValue(double value);
        void Divide();
        List<double> GetStack();
        void Multiply();
        void Substract();
        void Sum();
        void Clear();
    }
}