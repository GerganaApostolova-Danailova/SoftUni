using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());

            double numResult = GetResult(num1,operators,num2);
            Console.WriteLine(numResult);


        }

        static double GetResult(double num1, string operators, double num2)
        {

            double result = 0;

            if (operators == "/")
            {
                result = (num1 / num2);
            }
            else if (operators == "*")
            {
                result =  (num1 * num2);
            }
            else if (operators == "+")
            {
                result = (num1 + num2);
            }
            else if (operators == "-")
            {
                result = (num1 - num2);
            }
            return result;
        }
    }
}
