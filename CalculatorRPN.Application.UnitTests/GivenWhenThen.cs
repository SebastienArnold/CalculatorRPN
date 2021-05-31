using System;
using System.Collections.Generic;

namespace CalculatorRPN.Application.UnitTests
{
    public abstract class GivenWhenThen
    {
        protected GivenWhenThen()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract void When();
    }
}
