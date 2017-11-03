using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class RegionRepository : RepositoryBase<Region, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Regions.Find(key);
            Context.Regions.Remove(item); 
        }

        public override IEnumerable<Region> GetAll()
        {
            return Context.Regions.ToList();
        }

        public override Region GetByKey(int key)
        {
            return Context.Regions.Find(key);
        }

        public override void Insert(Region item)
        {
            Context.Regions.Add(item);
        }

        public override void Update(Region item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
