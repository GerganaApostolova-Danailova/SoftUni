using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            if (number >= 30 && number < 100)
            {
                if (type == "Students")
                {
                    if (day == "Friday")
                    {
                        price = number * 8.45;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if(day == "Saturday")
                    {
                        price = number * 9.80;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 10.46;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (type == "Business")
                {
                    if (day == "Friday")
                    {
                        price = number * 10.90;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 15.60;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 16.00;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (type == "Regular")
                {
                    if (day == "Friday")
                    {
                        price = number * 15.00;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 20.00;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 22.50;
                        totalPrice = price - (price * 0.15);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
            }
            if (number >= 100)
            {
                if (type == "Students")
                {
                    if (day == "Friday")
                    {
                        price = (number - 10) * 8.45;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = (number - 10) * 9.80;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = (number - 10) * 10.46;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
                else if (type == "Business")
                {
                    if (day == "Friday")
                    {
                        price = (number - 10) * 10.90;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = (number - 10) * 15.60;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = (number - 10) * 16.00;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
                else if (type == "Regular")
                {
                    if (day == "Friday")
                    {
                        price = (number - 10) * 15.00;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = (number - 10) * 20.00;
                        
                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = (number - 10) * 22.50;
                        

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
            }
            else if (number >= 10 && number <= 20)
            {
                if (type == "Students")
                {
                    if (day == "Friday")
                    {
                        price = number * 8.45;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 9.80;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 10.46;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (type == "Business")
                {
                    if (day == "Friday")
                    {
                        price = number * 10.90;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 15.60;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 16.00;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
                else if (type == "Regular")
                {
                    if (day == "Friday")
                    {
                        price = number * 15.00;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 20.00;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 22.50;
                        totalPrice = price - (price * 0.05);

                        Console.WriteLine($"Total price: {totalPrice:f2}");
                    }
                }
            }
            else if (number >0 && number <10 && number > 20 && number <30)
            {
                if (type == "Students")
                {
                    if (day == "Friday")
                    {
                        price = number * 8.45;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 9.80;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 10.46;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
                else if (type == "Business")
                {
                    if (day == "Friday")
                    {
                        price = number * 10.90;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 15.60;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 16.00;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
                else if (type == "Regular")
                {
                    if (day == "Friday")
                    {
                        price = number * 15.00;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Saturday")
                    {
                        price = number * 20.00;

                        Console.WriteLine($"Total price: {price:f2}");
                    }
                    else if (day == "Sunday")
                    {
                        price = number * 22.50;


                        Console.WriteLine($"Total price: {price:f2}");
                    }
                }
            }
        }
    }
}
