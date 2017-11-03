using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInsp.Core.Repository
{
    public abstract class RepositoryBase<V, K> : IRepository<V, K>
    {
        #region Methods

        public abstract IEnumerable<V> GetAll();
        public abstract V GetByKey(K key);
        public abstract void Insert(V item);
        public abstract void Delete(K key);
        public abstract void Update(V item);

        public void Save()
        {
            Context?.SaveChanges();
        }

        #endregion


        #region Properties

        public AppContext Context
        {
            get
            {
                return AppContext.Instance;
            }
        }

        #endregion
    }
}
