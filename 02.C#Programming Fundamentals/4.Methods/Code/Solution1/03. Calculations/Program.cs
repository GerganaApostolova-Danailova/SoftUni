using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                PrintAdd(num1, num2);               

            }
            else if (command == "multiply")
            {
               
                    PrintMultiply(num1, num2);

                
            }
            else if (command == "subtract")
            {

                PrintSubtract(num1,num2);

            }
            else if (command == "divide")
            {

                PrintDivide(num1,num2); 

            }
        }

        private static void PrintDivide(int num1, int num2)
        {
            Console.WriteLine(num1 / num2);
        }

        private static void PrintSubtract(int num1, int num2)
        {
           
            Console.WriteLine(num1 - num2);
        }

        static void PrintAdd(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void PrintMultiply(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }
    }
}
