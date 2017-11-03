using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInsp.Core.Repository
{
    public sealed class TemplateRepository : RepositoryBase<AppContext, Template, int>
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

        public IEnumerable<Question> GetAllQuestions()
        {
            return Context.Questions.ToList();
        }

        public IEnumerable<Question> GetQuestionsFromTemplate(int id)
        {
            return Context.Questions.Where(o => o.Template.TemplateID == id).ToList();
        }

        public override Template GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void LinkQuestionToTemplate(int key, Template template)
        {
            Context.Questions.Find(key).Template = template;
        }

        public void UnLinkQuestionToTemplate(int key)
        {
            Context.Questions.Find(key).Template = null;
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
