using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GoInsp.Core.Repository.Generic
{
    public sealed class QuestionRepository : RepositoryBase<Question, int>
    {
        #region Methods

        public override void Delete(int key)
        {
            var item = Context.Questions.Find(key);
            Context.Questions.Remove(item); 
        }

        public override IEnumerable<Question> GetAll()
        {
            return Context.Questions.ToList();
        }

        public override Question GetByKey(int key)
        {
            return Context.Questions.Find(key);
        }

        public override void Insert(Question item)
        {
            Context.Questions.Add(item);
        }

        public override void Update(Question item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        #endregion
    }
}
