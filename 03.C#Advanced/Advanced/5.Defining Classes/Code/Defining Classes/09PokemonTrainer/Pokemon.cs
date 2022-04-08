using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        private string pokemonName;
        private string pokemonElement;
        private int pokemonHealt;

        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealt)
        {
            PokemonName = pokemonName;
            PokemonElement = pokemonElement;
            PokemonHealt = pokemonHealt;
        }

        public string PokemonName
        {
            get { return pokemonName; }
            set { pokemonName = value; }
        }

        public string PokemonElement
        {
            get { return pokemonElement; }
            set { pokemonElement = value; }
        }

        public int PokemonHealt
        {
            get { return pokemonHealt; }
            set { pokemonHealt = value; }
        }
    }
}
