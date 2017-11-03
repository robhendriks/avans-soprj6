using System;
using System.Collections.Generic;

namespace GoInsp.Core.Repository
{
    public interface IRepository<V, K>
    { 
        #region Methods

        IEnumerable<V> GetAll();
        V GetByKey(K key);
        void Insert(V item);
        void Delete(K key);
        void Update(V item);
        void Save();

        #endregion
    }
}
