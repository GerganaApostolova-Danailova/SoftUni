namespace AnimalFarm
{
    using System;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(chicken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
