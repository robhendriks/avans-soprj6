using FlexAuth.Input;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Core.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<UserViewModel> Users { get; set; }
        public ObservableCollection<RoleViewModel> UsedRoles { get; set; }
        public ObservableCollection<RoleViewModel> AvailableRoles { get; set; }
        public ObservableCollection<CompanyViewModel> Companies { get; set; }
        
        public UserRepository userRepo = new UserRepository();
        public RoleRepository roleRepo = new RoleRepository();
        public CompanyRepository companyRepo = new CompanyRepository();
        public UserRoleRepository userRoleRepo = new UserRoleRepository();

        public ICommand AddUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand SaveUserCommand { get; set; }
        public ICommand ChangeToAvailable { get; set; }
        public ICommand ChangeToUsed { get; set; }
        public ICommand StopAddingUser { get; set; }

        private UserViewModel _selectedItem;
        public UserViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                AreControlsEnabled = false;

                if (_selectedItem != null)
                {
                    PopulateUsedRoles();
                    PopulateAvailableRoles();
                    PopulateCompanies();

                    AreControlsEnabled = true;
                    RaisePropertyChanged("SelectedItem");
                }
                else
                {
                    UsedRoles = AvailableRoles = null;
                    RaisePropertyChanged("AvailableRoles");
                }
            }
        }

        private RoleViewModel _selectedAvailableRole;
        public RoleViewModel SelectedAvailableRole
        {
            get { return _selectedAvailableRole; }
            set
            {
                _selectedAvailableRole = value;
                RaisePropertyChanged("SelectedAvailableRole");
            }
        }

        private RoleViewModel _selectedUsedRole;
        public RoleViewModel SelectedUsedRole
        {
            get { return _selectedUsedRole; }
            set
            {
                _selectedUsedRole = value;
                RaisePropertyChanged("SelectedUsedRole");
            }
        }

        private CompanyViewModel _selectedCompany;
        public CompanyViewModel SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                _selectedCompany = value;

                if (_selectedCompany != null)
                {
                    SelectedItem.User.Company = value.Company;
                }
                RaisePropertyChanged("SelectedCompany");
            }
        }

        public UsersViewModel()
            : base()
        {
            Populate();

            AddUserCommand = new RelayCommand(AddUserTab);
            DeleteUserCommand = new RelayCommand(DeleteUserTab);
            SaveUserCommand = new RelayCommand(SaveUser);
            ChangeToAvailable = new RelayCommand(OnChangeToAvailable);
            ChangeToUsed = new RelayCommand(OnChangeToUsed);
            StopAddingUser = new AuthCommand(ToggleLightBoxOff);
        }

        private void Populate()
        {
            IEnumerable<User> users = userRepo.GetAll();
            IEnumerable<UserViewModel> usersVM = users
                .Select(o => new UserViewModel(o));

            Users = new ObservableCollection<UserViewModel>(usersVM);
            RaisePropertyChanged("Users");
        }

        public void PopulateUsedRoles()
        {
            IEnumerable<UserRole> userRole = SelectedItem.UserRoles;
            IEnumerable<RoleViewModel> rolesVM = userRole
               .Select(o => new RoleViewModel(o.Role));

            UsedRoles = new ObservableCollection<RoleViewModel>(rolesVM);
            RaisePropertyChanged("UsedRoles");
        }

        public void PopulateAvailableRoles()
        {
            IEnumerable<Role> roles = roleRepo.GetAll();
            IEnumerable<RoleViewModel> rolesVM = roles
                .Select(o => new RoleViewModel(o));

            AvailableRoles = new ObservableCollection<RoleViewModel>(
                from n1 in rolesVM
                where !(from n2 in UsedRoles
                        select n2.RoleID)
                       .Contains(n1.RoleID)
                select n1);

            RaisePropertyChanged("AvailableRoles");
        }

        public void PopulateCompanies()
        {
            IEnumerable<Company> companies = companyRepo.GetAll();
            IEnumerable<CompanyViewModel> companiesVM = companies
                .Select(o => new CompanyViewModel(o));

            Companies = new ObservableCollection<CompanyViewModel>(companiesVM);

            SelectedCompany = Companies.Where(o => o.CompanyID == SelectedItem.UserCompanyID).SingleOrDefault();
            RaisePropertyChanged("Companies");
        }

        private void AddUserTab()
        {
            FlexMenuManager.Instance.OpenLightbox();

            SelectedItem = new UserViewModel();
            RaisePropertyChanged("Companies");
            

            AreControlsEnabled = false;
            
        }

        private void DeleteUserTab()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show(String.Format("Weet u zeker dat u {0} {1} werkzaam bij {2}, wilt verwijderen?", 
                SelectedItem.UserFirstName,
                SelectedItem.UserLastName,
                SelectedItem.User.Company.CompanyName), "Bevestiging", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                userRepo.Delete(SelectedItem.User.UserID);
                Users.Remove(SelectedItem);
                userRepo.Save();

                SelectedItem = null;
                AreControlsEnabled = false;
                RaisePropertyChanged("EntryDeleted");
            }
        }

        //TODO: input validatie
        private void SaveUser()
        {
            try {
                if (!Users.Contains(SelectedItem))
                {
                    
                    SelectedItem.UserCompanyID = SelectedCompany.CompanyID;
                    userRepo.Insert(SelectedItem.User);
                    userRepo.Save();
                    Users.Add(SelectedItem);
                }

                userRepo.Save();
                
                RaisePropertyChanged("DataSaved");
                ToggleLightBoxOff();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Validatie errors");
            }

        }

        protected void OnChangeToAvailable()
        {
            var tmp = SelectedUsedRole;

            if (tmp == null)
            {
                System.Windows.MessageBox.Show("Selecteer a.u.b. een item");
                return;
            }

            var userRole = GetByUserIDAndRoleID(
                SelectedItem.UserID,
                SelectedUsedRole.RoleID);

            if (userRole != null)
            {
                userRoleRepo.Delete(userRole.UserRoleID);

                AvailableRoles.Add(_selectedUsedRole);
                RaisePropertyChanged("AvailableRoles");

                UsedRoles.Remove(_selectedUsedRole);
                RaisePropertyChanged("UsedRoles");
            }
            else
                System.Windows.MessageBox.Show("Onverwachte fout");

            SaveUser();
        }

        protected void OnChangeToUsed()
        {
            var tmp = SelectedAvailableRole;

            if (tmp == null)
            {
                System.Windows.MessageBox.Show("Selecteer a.u.b. een item");
                return;
            }

            var userRole = new UserRole()
            {
                UserID = _selectedItem.UserID,
                RoleID = _selectedAvailableRole.RoleID
            };
            
            userRoleRepo.Insert(userRole);

            UsedRoles.Add(_selectedAvailableRole);
            RaisePropertyChanged("UsedRoles");

            AvailableRoles.Remove(_selectedAvailableRole);
            RaisePropertyChanged("AvailableRoles");

            SaveUser();
        }

        private UserRole GetByUserIDAndRoleID(int userID, int roleID)
        {
            IEnumerable<UserRole> userRoles = userRoleRepo.GetAll();
            return userRoles
                .Where(o => o.UserID.Equals(userID))
                .Where(o => o.RoleID.Equals(roleID))
                .SingleOrDefault();
        }

        public void ToggleLightBoxOff()
        {
            FlexMenuManager.Instance.CloseLightbox();
        }

        private bool _areControlsEnabled;
        public bool AreControlsEnabled
        {
            get
            {
                return _areControlsEnabled;
            }
            set
            {
                if (_areControlsEnabled == value) return;
                _areControlsEnabled = value;
                RaisePropertyChanged("AreControlsEnabled");
            }
        }
    }
}
