using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class QuestionTypeRepository : RepositoryBase<QuestionType, Guid>
    {
        #region Methods

        public override void Delete(Guid key)
        {
            var item = Context.QuestionTypes.Find(key);
            Context.QuestionTypes.Remove(item); 
        }

        public override IEnumerable<QuestionType> GetAll()
        {
            return Context.QuestionTypes.ToList();
        }

        public override QuestionType GetByKey(Guid key)
        {
            return Context.QuestionTypes.Find(key);
        }

        public override void Insert(QuestionType item)
        {
            Context.QuestionTypes.Add(item);
        }

        public override void Update(QuestionType item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
