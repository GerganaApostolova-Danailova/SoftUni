using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Heroes hero = new Heroes();

            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();

                string type = Console.ReadLine();

                BaseHero hero = CreateType(type, name);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }


            int baseHeroPower = int.Parse(Console.ReadLine());

            heroes.ForEach(h => Console.WriteLine(h.CastAbility()));

            int sum = heroes.Sum(x => x.Power);

            if (sum >= baseHeroPower )
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateType(string type, string name)
        {
            BaseHero hero = null;

            if (type == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
