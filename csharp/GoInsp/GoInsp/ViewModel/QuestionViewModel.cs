using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GoInsp.Core.Model;

namespace GoInsp.ViewModel
{
    public class QuestionViewModel :  BaseViewModel
    {

        //VARIABLES
        #region Variables
       
        private Question _question;
        #endregion

        #region Properties
        public string QuestionDescription
        {
            get { return _question.QuestionDescription; }

            set { _question.QuestionDescription = value;
                RaisePropertyChanged("QuestionDescription");
            }
        }

        public ICollection<Answer> Answers
        {
            get { return _question.Answers; }
            set
            {
                _question.Answers = value;
                RaisePropertyChanged("Answers");
            }
        }

        public QuestionType QuestionType
        {
            get { return _question.QuestionType; }
            set
            {
                _question.QuestionType = value;
                RaisePropertyChanged("QuestionType");
            }
        }

        public int QuestionID
        {
            get { return _question.QuestionID; }
            set { _question.QuestionID = value;
                RaisePropertyChanged("QuestionID");
            }
        }

        public int QuestionTypeID
        {
            get { return _question.QuestionTypeID; }
            set
            {
                _question.QuestionTypeID = value;
            }
        }

        private string _questionInTemplate;
        public string QuestionInTemplate
        {
            get { return _questionInTemplate; }
            set
            {
                _questionInTemplate = value;
                RaisePropertyChanged("QuestionInTemplate");
            }
        }
	
        public string QuestionTitle
        {
            get { return _question.QuestionTitle; }

            set { _question.QuestionTitle = value;
                RaisePropertyChanged("QuestionTitle");
            }
        }

        public Question Question
        {
            get { return _question; }
            set { _question = value;
                RaisePropertyChanged("Question");
            }
        }

        #endregion

        #region Constructors
        public QuestionViewModel()
        {
            Question = new Question();
           

        }

        public QuestionViewModel(Question q)
        {
            Question = q ?? new Question();

        }
        #endregion

        #region ToPoco

        public Question ToPoco()
        {
            return _question;
        }
		
        #endregion
    }
}
