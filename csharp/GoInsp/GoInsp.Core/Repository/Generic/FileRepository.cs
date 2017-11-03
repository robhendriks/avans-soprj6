using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class FileRepository : RepositoryBase<File, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.Files.Find(key);
            Context.Files.Remove(item); 
        }

        public override IEnumerable<File> GetAll()
        {
            return Context.Files.ToList();
        }

        public override File GetByKey(Guid key)
        {
            return Context.Files.Find(key);
        }

        public override void Insert(File item)
        {
            Context.Files.Add(item);
        }

        public override void Update(File item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
