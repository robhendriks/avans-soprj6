using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class CompanyRepository : RepositoryBase<Company, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Companies.Find(key);
            Context.Companies.Remove(item); 
        }

        public override IEnumerable<Company> GetAll()
        {
            return Context.Companies.ToList();
        }

        public override Company GetByKey(int key)
        {
            return Context.Companies.Find(key);
        }

        public override void Insert(Company item)
        {
            Context.Companies.Add(item);
        }

        public override void Update(Company item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
