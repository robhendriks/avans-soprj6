using FlexAuth.Input;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using System.Net.NetworkInformation;
using System.Threading;
using GalaSoft.MvvmLight.Command;

namespace GoInsp.ViewModel
{
    public class PerformInspectionViewModel : BaseViewModel
    {
        //public ObservableCollection<InstanceQuestionViewModel> OpenQuestions { get; set; }
        //public ObservableCollection<InstanceQuestionViewModel> MultipleChoiceQuestions { get; set; }

        public ObservableCollection<String> FileNames { get; set; }
        public CloudStorageAccount storageAccount { get; set; }
        public CloudBlobClient blobClient { get; set; }
        public CloudBlobContainer container { get; set; }

        public String ConnectionImage { get; set; }

        private Microsoft.Win32.OpenFileDialog dlg;
        private bool? result;

        public String UploadingVisibility { get; set; }

        private InspectionViewModel _selectedInpection;
        public InspectionViewModel SelectedInpection
        {
            get
            {
                return _selectedInpection;
            }

            set
            {

                _selectedInpection = value;
            }
        }

        private QuestionViewModel _selectedItem;
        public QuestionViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
            }
        }

        public ICommand SaveChanges { get; set; }
        public ICommand AddMedia { get; set; }
        public ICommand SaveInspection { get; set; }

        private Thread thread { get; set; }


        private ICommand _deleteFileFromInspection;
        public ICommand DeleteFileFromInspection
        {
            get
            {
                if (_deleteFileFromInspection == null)
                    _deleteFileFromInspection = new RelayCommand<String>(i => DeleteFile(i));
                return _deleteFileFromInspection;
            }
        }

        private ICommand _setSelectedAnswer;
        public ICommand SetSelectedAnswer
        {
            get
            {
                if (_setSelectedAnswer == null)
                    _setSelectedAnswer = new RelayCommand<Answer>(i => SetSelectedAnswerVoid(i));
                return _setSelectedAnswer;
            }
        }

        private ICommand _setOptional;
        public ICommand SetOptional
        {
            get
            {
                if (_setOptional == null)
                    _setOptional = new RelayCommand<long>(i => SetOptionalForQuestion(i));
                return _setOptional;
            }
        }

        public PerformInspectionViewModel()
            : base()
        {

            //SelectedInpection = new InspectionViewModel(Context.Inspections.FirstOrDefault());

            PopulateQuestions();

            SaveChanges = new AuthCommand(Save);
            AddMedia = new AuthCommand(AddFile);
            SaveInspection = new RelayCommand(Save);

            UploadingVisibility = "Hidden";

            FileNames = new ObservableCollection<string>();

            if (CheckInternetConnection())
            {
                InitAzure();
                ConnectionImage = "Resources/Generic/Online.png";
            }
            else
                ConnectionImage = "Resources/Generic/Offline.png";

            RaisePropertyChanged("ConnectionImage");
        }

        private void SetOptionalForQuestion(long id)
        {
            //MultipleChoiceQuestions.Where(o => o.QuestionID == id).Single().OptionalValue = true;
        }

        private void SetSelectedAnswerVoid(Answer value)
        {
            //SelectedInpection.Instance.Values.Where(o => o.ValueQuestionID == value.AnswerQuestionID).Single().ValueText = value.AnswerTitle;
            //SelectedInpection.Instance.Values.Where(o => o.ValueQuestionID == value.AnswerQuestionID).Single().ValueTitle = value.Question.QuestionTitle;
            //MultipleChoiceQuestions.Where(o => o.QuestionID == value.AnswerQuestionID).Single().OptionalValue = false;
            //Context.SaveChanges();
        }

        private bool CheckInternetConnection()
        {
            bool connection = true;

            try
            {
                new Ping().Send("www.google.com.mx");
            }
            catch (Exception)
            {
                connection = false;
            }

            return connection;
        }

        private void InitAzure()
        {
            storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            blobClient = storageAccount.CreateCloudBlobClient();
            container = blobClient.GetContainerReference("inspection" + SelectedInpection.InspectionID.ToString());
            container.CreateIfNotExists();
            GetAttachments();
        }

        private void GetAttachments()
        {
            FileNames = new ObservableCollection<string>();

            foreach (IListBlobItem item in container.ListBlobs(null, false))
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    FileNames.Add(blob.Name);
                }

            RaisePropertyChanged("FileNames");
        }

        public void PopulateQuestions()
        {
            //IEnumerable<InstanceQuestion> multipleChoiceQuestion = Context.InstanceQuestions.Where(o => o.Question.QuestionTypeID == 2);
            //IEnumerable<InstanceQuestionViewModel> multipleChoiceQuestionVM = multipleChoiceQuestion
            //   .Select(o => new InstanceQuestionViewModel(o));

            //IEnumerable<InstanceQuestion> openQuestion = Context.InstanceQuestions.Where(o => o.Question.QuestionTypeID == 1);
            //IEnumerable<InstanceQuestionViewModel> openQuestionVM = openQuestion
            //   .Select(o => new InstanceQuestionViewModel(o));


            //MultipleChoiceQuestions = new ObservableCollection<InstanceQuestionViewModel>(multipleChoiceQuestionVM);
            //foreach (InstanceQuestionViewModel iqvm in MultipleChoiceQuestions)
            //    iqvm.OptionalValue = false;

            //RaisePropertyChanged("MultipleChoiceQuestions");

            //OpenQuestions = new ObservableCollection<InstanceQuestionViewModel>(openQuestionVM);
            //RaisePropertyChanged("OpenQuestions");
        }

        public void Save()
        {
            //foreach(InstanceQuestionViewModel iqv in OpenQuestions)
            //    foreach (Value v in SelectedInpection.Inspection.Instance.Values)
            //        if(v.ValueQuestionID == iqv.InstanceQuestionID)
            //        {
            //            v.ValueText = iqv.QuestionTempValue;
            //            v.ValueTitle = iqv.Question.QuestionTitle;
            //        }

            //foreach (InstanceQuestionViewModel iqv in MultipleChoiceQuestions)
            //    foreach (Value v in SelectedInpection.Inspection.Instance.Values)
            //        if (v.ValueQuestionID == iqv.InstanceQuestionID)
            //            if (iqv.OptionalValue)
            //            {
            //                v.ValueText = iqv.QuestionTempValue;
            //                v.ValueTitle = iqv.Question.QuestionTitle;
            //            }

            //Context.SaveChanges();
        }

        public void AddFile()
        {
            dlg = new Microsoft.Win32.OpenFileDialog();
            result = dlg.ShowDialog();

            if (result == true)
            {
                UploadingVisibility = "Visible";
                RaisePropertyChanged("UploadingVisibility");
                thread = new Thread(Upload);
                thread.Start();
            }
        } 

        private void Upload()
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(dlg.SafeFileName);

            using (var fileStream = System.IO.File.OpenRead(dlg.FileName))
            {
                blockBlob.UploadFromStream(fileStream);

                AsyncCallback callback = new AsyncCallback(toggle);
                blockBlob.BeginUploadFromStream(fileStream, callback, new object());
            }

            GetAttachments();
        }
        
        private void toggle(IAsyncResult result)
        {
            UploadingVisibility = "Hidden";
            RaisePropertyChanged("UploadingVisibility");
        }
        
        private void DeleteFile(String name)
        {
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(name);
            blockBlob.Delete();

            GetAttachments();
        }
    }
}
