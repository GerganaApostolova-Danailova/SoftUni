using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string MainPlayerName = "Tommy Vercetti";
        private const int InitializeLifePoints = 100;

        public MainPlayer()
            : base(MainPlayerName, InitializeLifePoints)
        {
        }
    }
}
