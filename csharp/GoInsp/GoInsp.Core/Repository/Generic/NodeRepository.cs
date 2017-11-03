using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class NodeRepository : RepositoryBase<Node, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Nodes.Find(key);
            Context.Nodes.Remove(item); 
        }

        public override IEnumerable<Node> GetAll()
        {
            return Context.Nodes.ToList();
        }

        public override Node GetByKey(int key)
        {
            return Context.Nodes.Find(key);
        }

        public override void Insert(Node item)
        {
            Context.Nodes.Add(item);
        }

        public override void Update(Node item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
