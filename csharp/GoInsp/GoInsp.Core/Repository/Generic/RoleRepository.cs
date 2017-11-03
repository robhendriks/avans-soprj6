using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class RoleRepository : RepositoryBase<Role, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Roles.Find(key);
            Context.Roles.Remove(item); 
        }

        public override IEnumerable<Role> GetAll()
        {
            return Context.Roles.ToList();
        }

        public override Role GetByKey(int key)
        {
            return Context.Roles.Find(key);
        }

        public override void Insert(Role item)
        {
            Context.Roles.Add(item);
        }

        public override void Update(Role item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
