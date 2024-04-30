using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZC_AppDevCalc
{
    public class DivideByZeroCalcException : Exception
    {
        public DivideByZeroCalcException() { }
        public DivideByZeroCalcException(string message) : base(message) { }

        public DivideByZeroCalcException(string message , Exception exception): base(message,exception) { }
    }
    public class OperationCauseOverflowCalcException : Exception 
    {
        public OperationCauseOverflowCalcException() { }
        public OperationCauseOverflowCalcException(string message) : base(message) { }

        public OperationCauseOverflowCalcException(string message, Exception exception) : base(message, exception) { }
    }
}
