using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZC_AppDevCalc
{
    internal interface InterfaceCalc
    {
        double Result { get; set; }
        void CancelLast();
        void Summarize(double x);
        void Multiply(double x);
        void Divide(double x);
        void Subtract(double x);

        event EventHandler<EventArgs> MyEventHandler;
    }
}
