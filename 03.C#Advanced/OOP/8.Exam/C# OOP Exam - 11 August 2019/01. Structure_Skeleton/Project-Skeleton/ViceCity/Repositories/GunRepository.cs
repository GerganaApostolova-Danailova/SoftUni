using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models
            => models.AsReadOnly();

        public void Add(IGun model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
            }
        }

        public IGun Find(string name)
        {
            return models.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }
    }
}
