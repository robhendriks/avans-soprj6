using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class LocationRepository : RepositoryBase<Location, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.Locations.Find(key);
            Context.Locations.Remove(item); 
        }

        public override IEnumerable<Location> GetAll()
        {
            return Context.Locations.ToList();
        }

        public override Location GetByKey(Guid key)
        {
            return Context.Locations.Find(key);
        }

        public override void Insert(Location item)
        {
            Context.Locations.Add(item);
        }

        public override void Update(Location item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
