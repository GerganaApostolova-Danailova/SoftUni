using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Repositories.Contracts
{
    public class DecorationRepository<IDecoration> : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var targetType = this.models.Find(m => m.GetType().Name == type);

            if (targetType == null)
            {
                return targetType;
            }
            return targetType;
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
