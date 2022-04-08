using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players.Contracts
{
    public interface ICivilPlayer
    {
        string Name { get; }

        bool IsAlive { get; }

        IRepository<IGun> GunRepository { get; }

        int LifePoints { get; }

        void TakeLifePoints(int points);
            
    }
}
