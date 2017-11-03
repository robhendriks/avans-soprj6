using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {

        #region Variable

        #endregion

        #region ViewModelLocator
        ViewModelLocator vml;
        QuestionsViewModel qvm;
        #endregion

        #region Properties

        private int _questiontype;
        public int QuestionType
        {
            get
            {
                return _questiontype;
            }

            set
            {
                _questiontype = value;
                qvm.AddQuestionId = _questiontype;
                RaisePropertyChanged("QuestionType");
            }
        }

        private string _questiontitle;
        public string QuestionTitle
        {
            get
            {
                return _questiontitle;
            }

            set
            {
                _questiontitle = value;
                qvm.AddQuestionText = _questiontitle;
                RaisePropertyChanged("QuestionTitle");
            }
        }

        private string _questiondescription;
        public string QuestionDescription
        {
            get
            {
                return _questiondescription;
            }
            set
            {
                _questiondescription = value;
                qvm.AddQuestionDescription = _questiondescription;
                RaisePropertyChanged("QuestionDescription");
            }
        }

        #endregion

        #region Commands
        public ICommand AddQuestionCommand { get; set; }
        
        #endregion

        #region Constructor
        public AddQuestionViewModel()
        {
            vml = new ViewModelLocator();
            qvm = vml.Questions;
            AddQuestionCommand = new RelayCommand(AddQuestion);
        }
        #endregion

        #region Methods

        public void AddQuestion()
        {

            MessageBox.Show("Description: " + QuestionDescription + "\n Title: "+QuestionTitle + "\n Question type:" +QuestionType);
            qvm.AddQuestion();
        }
        #endregion
    }
}
