using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Core.Repository.Generic;

namespace GoInsp.ViewModel
{
    public class QuestionsViewModel : BaseViewModel
    {
        #region variable
        
        private Question _question;
        private Answer _answer;
        private QuestionRepository QuestionRepository { get; set; }
        private AnswerRepository AnswerRepository { get; set; }
        #endregion

        #region properties
        private ObservableCollection<QuestionViewModel> _questions { get; set; }
        public ObservableCollection<QuestionViewModel> Questions
        {
            get { return _questions; }
            set
            {
                _questions = value;
                RaisePropertyChanged("Questions");
            }
        }

        private ObservableCollection<AnswerViewModel> _answers { get; set; }
        public ObservableCollection<AnswerViewModel> Answers
        {
            get { return _answers; }
            set
            {
                _answers = value;
                RaisePropertyChanged("Questions");
            }
        }

        public Answer Answer
        {
            get
            {
                return _answer;
            }
            set
            {
                _answer = value;
                RaisePropertyChanged("Answer");
            }
        }
 
        private bool _ismeerkeuze;
        public bool IsMeerkeuze
        {
            get { return _ismeerkeuze; }
            set
            {
                _ismeerkeuze = value;
                RaisePropertyChanged("IsMeerkeuze");
                if (_ismeerkeuze)
                {
                    Visibility = "Visible";
                }
                else
                {
                    Visibility = "Hidden";
                }
            }
        }

        private string _visibility;
        public string Visibility
        {
            get
            {
                return _visibility;
            }

            set
            {
                _visibility = value;
                RaisePropertyChanged("Visibility");
            }
        }

        private string _addquestiontext;
        public string AddQuestionText
        {
            get { return _addquestiontext; }
            set { _addquestiontext = value;
                RaisePropertyChanged("AddQuestionText");
               
            }
        }

        private string _addquestiondescription;
        public string AddQuestionDescription
        {
            get
            {
                return _addquestiondescription;
            }
            set
            {
                _addquestiondescription = value;
                RaisePropertyChanged("AddQuestionDescription");
            }
        }

        private int _questionid;
        public int AddQuestionId
        {
            get { return _questionid; }
            set { _questionid = value;
                RaisePropertyChanged("AddQuestionId");
            }
        }

        private QuestionViewModel _questionviewmodel;
        public QuestionViewModel SelectedQuestion
        {
            get { return _questionviewmodel; }
            set
            {
                _questionviewmodel = value;
               
                if (_questionviewmodel != null)
                {
                    if (_questionviewmodel.QuestionTypeID == 2)
                    {
                        IsMeerkeuze = true;
                    }
                    else
                    {
                        IsMeerkeuze = false;
                    }
                }
                RaisePropertyChanged("SelectedQuestion");
                GetAnswers();
                RaisePropertyChanged("Answers");
              
            }
        }

        private AnswerViewModel _answerviewmodel;
        public AnswerViewModel SelectedAnswer
        {
            get
            {
                return _answerviewmodel;
            }

            set
            {
                _answerviewmodel = value;
                RaisePropertyChanged("SelectedAnswer");
            }
        }


        #endregion

        #region commands
        public ICommand AddQuestionCommand { get; set; }
        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand EditQuestionCommands { get; set; }
        public ICommand AddAnswerCommand { get; set; }
        public ICommand DeleteAnswerCommand { get; set; }
        public ICommand EditAnswerCommand { get; set; }
        public ICommand LightboxCloseCommand { get; set; }
        public ICommand LightboxOpenCommand { get; set; }
        #endregion

        #region constructor
        public QuestionsViewModel()
        {
            QuestionRepository = new QuestionRepository();
            GetQuestions();
            _question = new Question();
            _answer = new Answer();

            AddQuestionCommand = new RelayCommand(AddQuestion);
            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
            DeleteAnswerCommand = new RelayCommand(DeleteAnswer);
            LightboxCloseCommand = new RelayCommand(OnLightboxClose);
            LightboxOpenCommand = new RelayCommand(OnLightboxOpen);

            Visibility = "Hidden";
        }

        #endregion

        #region methods

        private void GetQuestions()
        {
            IEnumerable<Question> questions = QuestionRepository.GetAll();
            IEnumerable<QuestionViewModel> questionVM = questions
                .Select(o => new QuestionViewModel(o));

            Questions = new ObservableCollection<QuestionViewModel>(questionVM);
            RaisePropertyChanged("Questions");

        }

        private void GetAnswers()
        {
            if (SelectedQuestion != null)
            {
                IEnumerable<Answer> answers = SelectedQuestion.Answers;
                IEnumerable<AnswerViewModel> AnswerVM = answers
                    .Select(a => new AnswerViewModel(a));

                Answers = new ObservableCollection<AnswerViewModel>(AnswerVM);
                RaisePropertyChanged("Answers");
            }
        }

        public void AddQuestion()
        {
            if (!String.IsNullOrEmpty(_addquestiontext))
            {
                _question.QuestionDescription = _addquestiondescription;
                _question.QuestionTitle = _addquestiontext;

                switch (AddQuestionId)
                {
                    case 0:
                        _question.QuestionTypeID = 1;
                        break;
                    case 1:
                        _question.QuestionTypeID = 2;
                        break;
                }

                QuestionRepository.Insert(_question);
                QuestionRepository.Save();

                Questions.Add(new QuestionViewModel(_question));

                RaisePropertyChanged("Questions");
                _question = new Question();
                OnLightboxClose();

            }
            else
            {
                MessageBox.Show("Vul een vraag in", "Vraag", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }

        public void DeleteQuestion()
        {
            
            //CAST QUESTIONVIEWMODEL TO QUESTION
            Question question = SelectedQuestion.ToPoco();
            
            //DELETE QUESTION ANSWERS
            var answers = question.Answers;
            foreach(var a in answers)
            {
                AnswerRepository.Delete(a.AnswerID);
            }

            //REMOVE QUESTION
            QuestionRepository.Delete(question.QuestionID);
            QuestionRepository.Save();
      
            Questions.Remove(SelectedQuestion);
            ResetData();

        }

        public void DeleteAnswer()
        {
            if (SelectedAnswer != null)
            {
                Answer answer = SelectedAnswer.ToPoco();

                AnswerRepository.Delete(answer.AnswerID);

                SelectedQuestion.Answers.Remove(answer);
                Answers.Remove(SelectedAnswer);
                AnswerRepository.Save();
                RaisePropertyChanged("Answers");
            }
        }

        public void AddAnswer()
        {
            
            
        }

        public void EditAnswer()
        {

        }

        public void EditQuestion()
        {

        }

        private void ResetData()
        {
            SelectedQuestion = null;
            Visibility = "Hidden";
            Answers = null;
            RaisePropertyChanged("Answers");
        }

        protected virtual void OnLightboxOpen()
        {
            FlexMenuManager.Instance.OpenLightbox();
        }

        protected virtual void OnLightboxClose()
        {
            FlexMenuManager.Instance.CloseLightbox();
        }
        #endregion
    }
}
