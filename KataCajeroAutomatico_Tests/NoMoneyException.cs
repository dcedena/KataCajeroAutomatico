using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataCajeroAutomatico_Tests
{
    public class NoMoneyException : Exception
    {
        public NoMoneyException()
        {
        }

        public NoMoneyException(string message) : base(message)
        {
        }
    }
}