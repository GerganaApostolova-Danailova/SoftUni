using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            this.Data = new List<T>();
        }
        protected List<T> Data { get; set; }

        public void Add(T model)
        {
            this.Data.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Data.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return this.Data.Remove(model);
        }
    }
}
