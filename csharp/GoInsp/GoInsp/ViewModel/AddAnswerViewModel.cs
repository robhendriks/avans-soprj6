using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class AddAnswerViewModel : ViewModelBase
    {

        #region Variable
        private ViewModelLocator vml;
        private QuestionsViewModel qvm;
        #endregion

        #region Properties
        private string _answertitle;
        public string AnswerTitle
        {
            get
            {
                return _answertitle;
            }
            set
            {
                _answertitle = value;
                qvm.Answer.AnswerTitle = value;
                RaisePropertyChanged("AnswerTitle");
            }
        }

        private string _answerdescription;
        public string AnswerDescription
        {
            get
            {
                return _answerdescription;
            }

            set
            {
                _answerdescription = value;
                qvm.Answer.AnswerDescription = value;
                RaisePropertyChanged("AnswerDescription");
            }
        }
        #endregion

        #region Commands
        public ICommand AddAnswerCommand { get; set; }
        #endregion

        #region Constructor
        public AddAnswerViewModel()
        {
            vml = new ViewModelLocator();
            qvm = vml.Questions;

            AddAnswerCommand = new RelayCommand(AddAnswer);
        }
        #endregion

        #region Methods
        public void AddAnswer()
        {
            qvm.AddAnswer();
        }
        #endregion
    }
}
