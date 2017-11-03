using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInsp.ViewModel
{
    public class AnswerViewModel : ViewModelBase
    {

        private Answer _answer;

        public int AnswerID
        {
            get
            {
                return _answer.AnswerID;
            }
            set
            {
                _answer.AnswerID = value;
                RaisePropertyChanged("AnswerID");
            }

        }

        public int AnswerQuestionID
        {
            get
            {
                return _answer.AnswerQuestionID;
            }
            set
            {
                _answer.AnswerQuestionID = value;
                RaisePropertyChanged("AnswerQuestionID");
            }
        }

        public string AnswerTitle {
            get {
                return _answer.AnswerTitle;
            }
            set
            { _answer.AnswerTitle = value;
              RaisePropertyChanged("AnswerTitle");
            }

        }

        public string AnswerDescription
        {
            get
            {
                return _answer.AnswerDescription;
            }
            set
            {
                _answer.AnswerDescription = value;
                RaisePropertyChanged("AnswerDescription");
            }
        }

        public virtual Question Question
        {
            get
            {
                return _answer.Question;
            }
            set
            {
                _answer.Question = value;
                RaisePropertyChanged("Question");
            }
        }

        #region Constructors

        public AnswerViewModel()
        {
            _answer = new Answer();
        }

        public AnswerViewModel(Answer a)
        {
            _answer = a ?? new Answer();
        }

     
        #endregion

        public Answer ToPoco()
        {
            return _answer;
        }

    }
}
