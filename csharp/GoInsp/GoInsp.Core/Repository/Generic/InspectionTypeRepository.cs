using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class InspectionTypeRepository : RepositoryBase<InspectionType, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.InspectionTypes.Find(key);
            Context.InspectionTypes.Remove(item); 
        }

        public override IEnumerable<InspectionType> GetAll()
        {
            return Context.InspectionTypes.ToList();
        }

        public override InspectionType GetByKey(int key)
        {
            return Context.InspectionTypes.Find(key);
        }

        public override void Insert(InspectionType item)
        {
            Context.InspectionTypes.Add(item);
        }

        public override void Update(InspectionType item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
