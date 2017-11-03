using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class UserRepository : RepositoryBase<User, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Users.Find(key);
            Context.Users.Remove(item); 
        }

        public override IEnumerable<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public override User GetByKey(int key)
        {
            return Context.Users.Find(key);
        }

        public override void Insert(User item)
        {
            Context.Users.Add(item);
        }

        public override void Update(User item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
