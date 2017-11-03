using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository
{
    public sealed class AnswerRepository : RepositoryBase<AppContext, Answer, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Answers.Find(key);
            Context.Answers.Remove(item); 
        }

        public override IEnumerable<Answer> GetAll()
        {
            return Context.Answers.ToList();
        }

        public override Answer GetByKey(int key)
        {
            return Context.Answers.Find(key);
        }

        public override void Insert(Answer item)
        {
            Context.Answers.Add(item);
        }

        public override void Update(Answer item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
