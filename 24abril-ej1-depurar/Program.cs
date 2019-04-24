using System;
using System.Collections.Generic;


namespace _24abril_ej1_depurar
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error

            // Use a switch statement to do the math
            switch (op)
            {
                case "s":
                    result = num1 + num2;
                    break;
                case "r":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry
                default:
                    break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app
            Console.WriteLine("calculadora en  C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number
                Console.Write("escribe un numero: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("no es un numero vuelve a poner numero: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number
                Console.Write("escribe otro numero: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("no es valido de nuevo: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator
                Console.WriteLine("elige uno:");
                Console.WriteLine("\ts - suma");
                Console.WriteLine("\tr - resta");
                Console.WriteLine("\tm -multiplicacion");
                Console.WriteLine("\td - division");
                Console.Write("elige ");

                string op = Console.ReadLine();

                double cuadrado=0;
                if (cleanNum1 < cleanNum2)
                {
                    cuadrado = cleanNum2 * cleanNum2;
                }
                if (cleanNum1 > cleanNum2)
                {
                    cuadrado = cleanNum1 * cleanNum1;
                }
                if (cleanNum1 == cleanNum2)
                {
                    cuadrado = cleanNum1 * cleanNum1;
                }

                try
                {
                  

                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("este operador da un error matematico.\n");
                    }
                    else Console.WriteLine("tu resultado: {0:0.##}\n", result );
                    Console.WriteLine("el doble es :",cuadrado);
                }
                
                catch (Exception e)
                {
                    Console.WriteLine("Error haciendo algo.\n - Details: " + e.Message);
                }
                
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing
                Console.Write("pulsa 'n' y cierra la app, o preciona cualquier tecla: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing
            }
            return;
        }
    }
}

