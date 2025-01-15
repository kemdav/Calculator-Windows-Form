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
        public static bool isUndefined = false;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Main_Window());
        }
        public static string CreateInputText()
        {
            string output = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                output += numbers[i];
                if (i < operations.Count)
                {
                    output += " " + operations[i] + " ";
                }
            }
            return output;
        }

        public static void Calculate()
        {
            if (numbers.Count == 0 || operations.Count == 0)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < operations.Count;j++)
                {
                    if (operations[j] == "x")
                    {
                        PerformOperation("x");
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "÷")
                    {
                        PerformOperation("÷");
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "+")
                    {
                        PerformOperation("+");
                    }
                }
                for (int j = 0; j < operations.Count; j++)
                {
                    if (operations[j] == "-")
                    {
                        PerformOperation("-");
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
                case "x":
                    result = firstNumber *= secondNUmber;
                    break;
                case "÷":
                    result = firstNumber /= secondNUmber;
                    if (secondNUmber == 0)
                    {
                        isUndefined = true;
                    }
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