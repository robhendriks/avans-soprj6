using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class AnswerInstanceRepository : RepositoryBase<AnswerInstance, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.AnswerInstances.Find(key);
            Context.AnswerInstances.Remove(item); 
        }

        public override IEnumerable<AnswerInstance> GetAll()
        {
            return Context.AnswerInstances.ToList();
        }

        public override AnswerInstance GetByKey(Guid key)
        {
            return Context.AnswerInstances.Find(key);
        }

        public override void Insert(AnswerInstance item)
        {
            Context.AnswerInstances.Add(item);
        }

        public override void Update(AnswerInstance item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
