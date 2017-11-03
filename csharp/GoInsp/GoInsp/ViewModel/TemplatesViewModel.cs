using FlexAuth.Security;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Core.Repository;
using GoInsp.Core.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class TemplatesViewModel : BaseViewModel
    {
        public ObservableCollection<TemplateViewModel> Templates { get; set; }
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public ObservableCollection<QuestionViewModel> QuestionsSearch { get; set; }
        public ObservableCollection<QuestionViewModel> QuestionsInTemplate { get; set; }
        public ObservableCollection<UserViewModel> Users { get; set; }

        public ICommand LightboxCloseCommand { get; set; }
        public ICommand AddNewItemCommand { get; set; }
        public ICommand NewTemplateCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public ICommand DeleteTemplateCommand { get; set; }
        public ICommand UpdateTemplateCommand { get; set; }

        private ICommand _linkQuestionToTemplate;
        public ICommand LinkQuestionToTemplate
        {
            get
            {
                //if (_linkQuestionToTemplate == null)
                //    _linkQuestionToTemplate = new RelayCommand<long>(i => AddQuestionToTemplate(i));
                return _linkQuestionToTemplate;
            }
        }

        private ICommand _unLinkQuestionToTemplate;
        public ICommand UnLinkQuestionToTemplate
        {
            get
            {
                //if (_unLinkQuestionToTemplate == null)
                //    _unLinkQuestionToTemplate = new RelayCommand<long>(i => RemoveQuestionFromTemplate(i));
                return _unLinkQuestionToTemplate;
            }
        }

        private ICommand _searchQuestions;
        public ICommand SearchQuestions
        {
            get
            {
                //if (_searchQuestions == null)
                //    _searchQuestions = new RelayCommand<string>(i => SearchQuestionsWithQuery(i));
                return _searchQuestions;
            }
        }

        public Boolean DetailsEnabled { get; set; }
        public Double DetailsOpacity { get; set; }
        public String errorMessage { get; set; }

        // Dynamic Popup
        public String LightBoxAddQuestionVisibility { get; set; }
        public String LightBoxNewVisibility { get; set; }
        public String LightBoxTitle { get; set; }
        public int LightboxWidth { get; set; }
        public int LightboxHeight { get; set; }

        private TemplateViewModel _selectedItemNew;
        public TemplateViewModel SelectedItemNew
        {
            get { return _selectedItemNew; }
            set
            {
                _selectedItemNew = value;
                RaisePropertyChanged("SelectedItemNew");
            }
        }

        private TemplateViewModel _selectedItem;
        public TemplateViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");

                getCurrentQuestions();

                if (SelectedItem != null)
                {
                    DetailsEnabled = true;
                    DetailsOpacity = 1;
                    RaisePropertyChanged("DetailsEnabled");
                    RaisePropertyChanged("DetailsOpacity");
                }
                else
                {
                    DetailsEnabled = false;
                    DetailsOpacity = 0.5;
                    RaisePropertyChanged("DetailsEnabled");
                    RaisePropertyChanged("DetailsOpacity");
                }
            }
        }

        public TemplateViewModel NewItem { get; set; }

        private TemplateRepository repo { get; set; }


        public TemplatesViewModel()
        {
            Populate();

            LightboxCloseCommand = new RelayCommand(OnLightboxClose);
            AddNewItemCommand = new RelayCommand(AddNewItem);
            NewTemplateCommand = new RelayCommand(SetNewTemplateContent);
            AddQuestionCommand = new RelayCommand(SetAddQuestionContent);
            DeleteTemplateCommand = new RelayCommand(DeleteItem);
            UpdateTemplateCommand = new RelayCommand(UpdateItem);

            NewItem = new TemplateViewModel();
            errorMessage = "";
            DetailsEnabled = false;
            DetailsOpacity = 0.5;

            LightBoxAddQuestionVisibility = "Hidden";
            LightBoxNewVisibility = "Hidden";
            LightBoxTitle = "";

            repo = new TemplateRepository();

            SetLightboxContent(2);
        }

        private void Populate()
        {
            //Templates = new ObservableCollection<TemplateViewModel>(repo.GetAll().Select(o => new TemplateViewModel(o)));
            //RaisePropertyChanged("Templates");

            //Questions = new ObservableCollection<QuestionViewModel>(repo.GetAllQuestions().Select(o => new QuestionViewModel(o)));
            //RaisePropertyChanged("Questions");
        }

        private void getCurrentQuestions()
        {
            //if(SelectedItem != null)
            //    QuestionsInTemplate = new ObservableCollection<QuestionViewModel>(repo.GetQuestionsFromTemplate(SelectedItem.TemplateID).Select(o => new QuestionViewModel(o));
            //else
            //    QuestionsInTemplate = new ObservableCollection<QuestionViewModel>();

            //RaisePropertyChanged("QuestionsInTemplate");
        }

        protected virtual void OnLightboxOpen()
        {
            FlexMenuManager.Instance.OpenLightbox();
        }

        protected virtual void OnLightboxClose()
        {
            FlexMenuManager.Instance.CloseLightbox();
        }

        private void AddNewItem()
        {
            if (NewItem.TemplateName == null || NewItem.TemplateName == "")
                errorMessage = "U heeft nog geen naam ingevoerd.";
            else if (NewItem.TemplateDescription == null || NewItem.TemplateDescription == "")
                errorMessage = "U heeft nog geen omschrijving ingevoerd.";
            else
            {
                // Toevoegen
                errorMessage = "";

                var user = UserManager.Instance.Current;

                if(user != null)
                {
                    var poco = user.Convert<User>();

                    TemplateViewModel newTemplate = new TemplateViewModel { TemplateName = NewItem.TemplateName, TemplateDescription = NewItem.TemplateDescription, TemplateUserID = poco.UserID, User = poco };
                    repo.Insert(newTemplate.Template);
                    repo.Save();
                
                    Templates.Add(newTemplate);
                    OnLightboxClose();
                }
                else
                {
                    errorMessage = "Geen gebruiker.";
                }
            }

            RaisePropertyChanged("errorMessage");
        }

        private void UpdateItem()
        {
            repo.Context.Templates.Where(o => o.TemplateID == SelectedItem.TemplateID).Single().TemplateName = SelectedItem.TemplateName;
            repo.Context.Templates.Where(o => o.TemplateID == SelectedItem.TemplateID).Single().TemplateDescription = SelectedItem.TemplateDescription;

            repo.Save();

            SelectedItem = null;
            RaisePropertyChanged("SelectedItem");
        }

        private void SetNewTemplateContent()
        {
            SetLightboxContent(1);
            OnLightboxOpen();
        }

        private void SetAddQuestionContent()
        {
            SetLightboxContent(2);
            OnLightboxOpen();
        }

        private void SetLightboxContent(int toggle)
        {
            if(toggle == 1)
            {
                LightBoxTitle = "Nieuwe template toevoegen";
                LightboxWidth = 300;
                LightboxHeight = 220;
                LightBoxNewVisibility = "Visible";
                LightBoxAddQuestionVisibility = "Hidden";
            }
            else if(toggle == 2)
            {
                LightBoxTitle = "Vraag koppelen aan template";
                LightboxWidth = 700;
                LightboxHeight = 300;
                LightBoxNewVisibility = "Hidden";
                LightBoxAddQuestionVisibility = "Visible";
            }

            RaisePropertyChanged("LightBoxTitle");
            RaisePropertyChanged("LightboxWidth");
            RaisePropertyChanged("LightboxHeight");
            RaisePropertyChanged("LightBoxNewVisibility");
            RaisePropertyChanged("LightBoxAddQuestionVisibility");
        }

        private void DeleteItem()
        {
            repo.Delete(SelectedItem.TemplateID);
            repo.Save();

            SelectedItem = null;

            RaisePropertyChanged("Templates");
            RaisePropertyChanged("SelectedItem");
            getCurrentQuestions();
        }

        private void AddQuestionToTemplate(int questionId)
        {
            //repo.LinkQuestionToTemplate(questionId, SelectedItem.Template);
            //repo.Save();

            getCurrentQuestions();
        }

        private void RemoveQuestionFromTemplate(int questionId)
        {
            //repo.UnLinkQuestionToTemplate(questionId);
            //repo.Save();

            getCurrentQuestions();
        }
    }
}
