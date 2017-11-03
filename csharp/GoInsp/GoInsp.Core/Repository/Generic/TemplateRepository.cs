using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class TemplateRepository : RepositoryBase<Template, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Templates.Find(key);
            Context.Templates.Remove(item); 
        }

        public override IEnumerable<Template> GetAll()
        {
            return Context.Templates.ToList();
        }

        public override Template GetByKey(int key)
        {
            return Context.Templates.Find(key);
        }

        public override void Insert(Template item)
        {
            Context.Templates.Add(item);
        }

        public override void Update(Template item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
