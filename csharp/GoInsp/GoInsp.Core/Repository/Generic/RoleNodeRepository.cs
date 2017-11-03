using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class RoleNodeRepository : RepositoryBase<RoleNode, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.RoleNodes.Find(key);
            Context.RoleNodes.Remove(item); 
        }

        public override IEnumerable<RoleNode> GetAll()
        {
            return Context.RoleNodes.ToList();
        }

        public override RoleNode GetByKey(int key)
        {
            return Context.RoleNodes.Find(key);
        }

        public override void Insert(RoleNode item)
        {
            Context.RoleNodes.Add(item);
        }

        public override void Update(RoleNode item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
