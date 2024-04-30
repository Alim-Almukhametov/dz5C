using System.Security.Permissions;

namespace DZC_AppDevCalc
{
   // Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами.
   // (возможно стоит задействовать перегрузку операций)
    internal class Program
    {
        static bool IsNumber(string s) 
        {
            if (double.TryParse(s, out double result)) 
            {
            return true;
            }
            return false;

        }
        static double Converter(string s) 
        {
            if (IsNumber(s)) 
            {
            return double.Parse(s);
            }
            return double.NaN;
        }
        static void Main(string[] args)
        {
            Calc calc1 = new Calc();

           

            calc1.MyEventHandler += Calc1_MyEventHandler;

            while (true) 
            {
                Console.WriteLine("Enter the  number");
                string inputNumber = Console.ReadLine() ?? "No Data";
                if (inputNumber.ToLower() =="cancel" || inputNumber.Length == 0) 
                {
                break;
                }
                double valueN;
                while (!IsNumber(inputNumber))
                {
                    Console.WriteLine("Enter number please");
                    inputNumber = Console.ReadLine() ?? "No Data";
                }

                valueN = Converter(inputNumber);


                Console.WriteLine("Choose the action");
                string input = Console.ReadLine()?? String.Empty;
               
                if (string.IsNullOrEmpty(input)) { break; }
                if (string.IsNullOrWhiteSpace(input) ) { break; }
                else 
                {
                    switch (input.ToLower()) 
                    {
                        case "*": calc1.Multiply(valueN); break;
                        case "-": calc1.Subtract(valueN); break;
                        case "+": calc1.Summarize(valueN); break;
                        case "/": calc1.Divide(valueN); break; // Перегрузила метод Хотя не совсем понимаю зачем
                            // так как если тип указан дабл и ввести инт то программа будет исправно работать так как
                            // дабл покрывает как инт , так и флоат и тд.
                        case "cancel": Console.WriteLine("Buy buy");
                        break;
                        default:  break;
                    }
                }

            }
            calc1.MyEventHandler -= Calc1_MyEventHandler;

            

            

            
        }

        private static void Calc1_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is Calc)
            {
                Console.WriteLine(((Calc)sender).Result);
            }
        }
    }
}
