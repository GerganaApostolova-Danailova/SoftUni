using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;

            try
            {
                box = new Box(lenght, width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (box != null)
            {
                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
        }
    }
}
