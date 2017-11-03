using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class InspectionRepository : RepositoryBase<Inspection, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.Inspections.Find(key);
            Context.Inspections.Remove(item); 
        }

        public override IEnumerable<Inspection> GetAll()
        {
            return Context.Inspections.ToList();
        }

        public override Inspection GetByKey(Guid key)
        {
            return Context.Inspections.Find(key);
        }

        public override void Insert(Inspection item)
        {
            Context.Inspections.Add(item);
        }

        public override void Update(Inspection item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<KeyValuePair<Int32, Int32>> GetInspectionsPerMonth()
        {
            IEnumerable<KeyValuePair<Int32, Int32>> query = from inspection in GetAll()
                                                            orderby inspection.InspectionStartTime.Value.Month
                                                            group inspection by inspection.InspectionStartTime.Value.Month into grp
                                                            select new KeyValuePair<Int32, Int32>(grp.Key, grp.Count());
            return query;
        }

        #endregion
    }
}
