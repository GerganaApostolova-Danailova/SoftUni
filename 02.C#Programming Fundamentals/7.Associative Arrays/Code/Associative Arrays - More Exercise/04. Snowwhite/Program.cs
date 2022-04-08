using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorNamePoint = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Once upon a time")
                {
                    break;
                }

                List<string> input = command
                    .Split(new[] { ' ', '<', '>', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string name = input[0];
                string color = input[1];
                int point = int.Parse(input[2]);


                if (!colorNamePoint.ContainsKey(color))
                {
                    colorNamePoint.Add(color, new Dictionary<string, int>());
                }
                if (!colorNamePoint[color].ContainsKey(name))
                {
                    colorNamePoint[color].Add(name, point);
                }
                if (colorNamePoint[color][name] < point)
                {
                    colorNamePoint[color][name] = point;
                }

            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var hatColor in colorNamePoint.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }


            //foreach (var kvp in colorNamePoint.OrderByDescending(x=>x.Value.Values.Max()))
            //{

            //    foreach (var item in kvp.Value)
            //    {
            //    Console.WriteLine($"({kvp.Key}) {item.Key} <-> {item.Value}");

            //    }
            //}
        }
    }
}
