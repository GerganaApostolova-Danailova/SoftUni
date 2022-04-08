using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoolSuplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int PackejOfPen = int.Parse(Console.ReadLine());
            int PackejOfMarker = int.Parse(Console.ReadLine());
            double LiterOfDetergent = double.Parse(Console.ReadLine());
            int Reduction = int.Parse(Console.ReadLine());
            double PricePen = PackejOfPen * 5.80;
            double PriceMarkers = PackejOfMarker * 7.20;
            double PriceofDetergent = LiterOfDetergent * 1.20;
            double PriceSupplies = PricePen + PriceMarkers + PriceofDetergent;
            double PriceWithReduction = PriceSupplies - ((PriceSupplies * Reduction) / 100);
            Console.WriteLine($"{PriceWithReduction:F3}");
        }
    }
}
