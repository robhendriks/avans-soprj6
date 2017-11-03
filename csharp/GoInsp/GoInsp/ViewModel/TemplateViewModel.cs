using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInsp.ViewModel
{
    public class TemplateViewModel : ViewModelBase
    {
        private Template _template;
        public Template Template
        {
            get { return _template; }
        }

        public TemplateViewModel()
        {
            _template = new Template();
        }

        public TemplateViewModel(Template template)
        {
            _template = template ?? new Template();
        }

        public int TemplateID
        {
            get { return _template.TemplateID; }
            set
            {
                _template.TemplateID = value;
                RaisePropertyChanged("TemplateID");
            }
        }

        public int? TemplateUserID
        {
            get { return _template.TemplateUserID; }
            set
            {
                _template.TemplateUserID = value;
                RaisePropertyChanged("TemplateUserID");
            }
        }

        public string TemplateName
        {
            get { return _template.TemplateName; }
            set
            {
                _template.TemplateName = value;
                RaisePropertyChanged("TemplateName");
            }
        }

        public string TemplateDescription
        {
            get { return _template.TemplateDescription; }
            set
            {
                _template.TemplateDescription = value;
                RaisePropertyChanged("TemplateDescription");
            }
        }

        public User User
        {
            get { return _template.User; }
            set
            {
                _template.User = value;
                RaisePropertyChanged("User");
            }
        }
    }
}
