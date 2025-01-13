using System;

namespace Calculator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        
        public static List<double> numbers = new List<double>();
        public static List<string> operations = new List<string>();
        public static string currentNumber = "";

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main_Window());
        }

        public static void Calculate()
        {
            if (numbers.Count == 0 || operations.Count == 0)
            {
                return;
            }

            for (int i = 0; i < operations.Count; i++)
            {
                for (int j = 0; j < operations.Count;j++)
                {
                    if (operations[j] == "*")
                    {
                        PerformOperation("*");
                        break;
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "/")
                    {
                        PerformOperation("/");
                        break;
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "+")
                    {
                        PerformOperation("+");
                        break;
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "-")
                    {
                        PerformOperation("-");
                        break;
                    }
                }
            }
        }

        static void PerformOperation(string operation)
        {
            var index = operations.IndexOf(operation);
            var firstNumber = numbers[index];
            var secondNUmber = numbers[index + 1];
            double result;
            switch (operation)
            {
                case "+":
                    result = firstNumber += secondNUmber;
                    break;
                case "-":
                    result = firstNumber -= secondNUmber;
                    break;
                case "*":
                    result = firstNumber *= secondNUmber;
                    break;
                case "/":
                    result = firstNumber /= secondNUmber;
                    break;
                default:
                    result = 0;
                    break;
            }
            numbers[index] = result;
            numbers.RemoveAt(index + 1);
            operations.RemoveAt(index);
        }

    }

}