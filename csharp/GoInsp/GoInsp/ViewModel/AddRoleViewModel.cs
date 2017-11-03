using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class AddRoleViewModel : ViewModelBase
    {
        #region Variable

        #endregion

        #region ViewModelLocator
        ViewModelLocator vml;
        RolesViewModel qvm;
        #endregion

        #region Properties

        private long _roleID;
        public long RoleID
        {
            get { return _roleID; }
            set
            {
                RoleID = value;
                RaisePropertyChanged("RoleID");
            }
        }

        private string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set
            {
                _roleName = value;
                RaisePropertyChanged("RoleName");
            }
        }

        private string _roleDescription;
        public string RoleDescription
        {
            get { return _roleDescription; }
            set
            {
                _roleDescription = value;
                RaisePropertyChanged("RoleDescription");
            }
        }

        #endregion

        #region Commands
        public ICommand AddQuestionCommand { get; set; }

        #endregion


        #region Constructor
        public AddRoleViewModel()
        {
            vml = new ViewModelLocator();
            qvm = vml.Roles;
            AddQuestionCommand = new RelayCommand(AddQuestion);
        }
        #endregion


        #region Methods

        public void AddQuestion()
        {
            //MessageBox.Show("Description: " + RoleDescription + "\n Name: " + RoleName);
            //qvm.AddNewRole();
        }
        #endregion
    }
}
