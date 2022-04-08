using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            Hero heroToRemuve = heroes.FirstOrDefault(x => x.Name == name);
            heroes.Remove(heroToRemuve);
        }

        public Hero GetHeroWithHighestStrength()
        {
            heroes = heroes.OrderByDescending(x => x.Item.Strength).ToList();
            Hero heroWithHighestStrength = heroes.First();
            return heroWithHighestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            heroes = heroes.OrderByDescending(x => x.Item.Ability).ToList();
            Hero heroWithHighestAbility = heroes.First();
            return heroWithHighestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            heroes = heroes.OrderByDescending(x => x.Item.Intelligence).ToList();
            Hero heroWithHighestIntelligence = heroes.First();
            return heroWithHighestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
