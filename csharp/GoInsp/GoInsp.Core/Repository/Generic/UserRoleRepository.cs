using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class UserRoleRepository : RepositoryBase<UserRole, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.UserRoles.Find(key);
            Context.UserRoles.Remove(item); 
        }

        public override IEnumerable<UserRole> GetAll()
        {
            return Context.UserRoles.ToList();
        }

        public override UserRole GetByKey(int key)
        {
            return Context.UserRoles.Find(key);
        }

        public override void Insert(UserRole item)
        {
            Context.UserRoles.Add(item);
        }

        public override void Update(UserRole item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
