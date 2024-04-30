using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DZC_AppDevCalc
    
{
    internal class Calc : InterfaceCalc
    {
        public double Result { get; set; } = 0;
        protected Stack<double> Results { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs>? MyEventHandler;

        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
        
        public void Divide(int x) 
        {
            if (x == 0)
            {
                throw new DivideByZeroCalcException("Can't divide by zero.");

            }
            else { Result /= x; }

            Results.Push(Result);
            PrintResult();

        }
        public void Divide(double x)
        {
            if (x == 0)
            {
                throw new DivideByZeroCalcException("Can't divide by zero.");

            }
            else { Result /= x; }

            Results.Push(Result);
            PrintResult();

        }
        public void Multiply(int x)
        {
            try
            {
                unchecked
                {
                    Result *= x;
                    Results.Push(Result);
                    PrintResult();
                }

            }
            catch
            {
                throw new OperationCauseOverflowCalcException("Overflow Exception");
            }


        }

        public void Multiply(double x)
        {
            try 
            {
                unchecked 
                {
                    Result *= x;
                    Results.Push(Result);
                    PrintResult();
                }
                
            }
            catch 
            {
                throw new OperationCauseOverflowCalcException("Overflow Exception");
            }
           

        }

        public void Subtract(double x)
        {
            Result -= x;
            Results.Push(Result);
            PrintResult();

        }
        public void Subtract(int x)
        {
            Result -= x;
            Results.Push(Result);
            PrintResult();

        }

        public void Summarize(double x)
        {
            try 
            {
                unchecked
                {
                    Result += x;
                    Results.Push(Result);
                    PrintResult();
                }
            }
            catch 
            {
            throw new OperationCauseOverflowCalcException("Overflow exception");
            }
         

        }
        public void Summarize(int x)
        {
            try
            {
                unchecked
                {
                    Result += x;
                    Results.Push(Result);
                    PrintResult();
                }
            }
            catch
            {
                throw new OperationCauseOverflowCalcException("Overflow exception");
            }


        }

        public void CancelLast()
        {
            if (Results.TryPop(out double res))
            {
                Result = res;
                PrintResult();
            }
            else Console.WriteLine("We can't cancel the last action.");
        }
    }
}
