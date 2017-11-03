using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class QuestionInstanceRepository : RepositoryBase<QuestionInstance, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.QuestionInstances.Find(key);
            Context.QuestionInstances.Remove(item); 
        }

        public override IEnumerable<QuestionInstance> GetAll()
        {
            return Context.QuestionInstances.ToList();
        }

        public override QuestionInstance GetByKey(Guid key)
        {
            return Context.QuestionInstances.Find(key);
        }

        public override void Insert(QuestionInstance item)
        {
            Context.QuestionInstances.Add(item);
        }

        public override void Update(QuestionInstance item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
