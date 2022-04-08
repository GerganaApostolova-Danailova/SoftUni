using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var colectionOfTrainers = new Dictionary<string, Trainer>();

            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Trainer currentTrainer = new Trainer(trainerName);
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);


                if (!colectionOfTrainers.ContainsKey(trainerName))
                {
                    colectionOfTrainers[trainerName] = currentTrainer;

                }
                colectionOfTrainers[trainerName].Pokemon.Add(currentPokemon);

            }
            while (true)
            {
                string elementOfPokemon = Console.ReadLine();

                if (elementOfPokemon == "End")
                {
                    break;
                }

                foreach (var trainer in colectionOfTrainers)
                {
                    var trainerToChek = trainer.Value;

                    if (trainerToChek.Pokemon.Any(p => p.PokemonElement == elementOfPokemon))
                    {
                        trainerToChek.NumberOfBadges ++;
                    }
                    else
                    {
                        for (int i = 0; i < trainerToChek.Pokemon.Count; i++)
                        {
                            var pokemonToCheck = trainerToChek.Pokemon[i];
                            if (pokemonToCheck.PokemonHealt > 10)
                            {
                                pokemonToCheck.PokemonHealt -= 10;
                            }
                            else
                            {
                                trainerToChek.Pokemon.Remove(pokemonToCheck);
                                i--;
                            }
                        }
                    }
                }


            }

            var sorted = colectionOfTrainers.OrderByDescending(t => t.Value.NumberOfBadges);

            foreach (var tr in sorted)
            {
                var trn = tr.Value;
                Console.WriteLine($"{trn.TrainerName} {trn.NumberOfBadges} {trn.Pokemon.Count}");
            }
        }
    }
}
