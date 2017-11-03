using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using GoInsp.Core.Repository.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoInsp.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        private User _user;

        public User User
        {
            get { return _user; }
        }

        public UserViewModel()
        {
            _user = new User();
        }

        public UserViewModel(User user)
        {
            _user = user ?? new User();
        }

        public int UserID
        {
            get { return _user.UserID; }
            set
            {
                _user.UserID = value;
                RaisePropertyChanged("UserID");
            }
        }

        // TO-DO: Add foreignkey constraint.
        public int? UserCompanyID
        {
            get { return _user.UserCompanyID; }
            set
            {
                _user.UserCompanyID = value;
                RaisePropertyChanged("UserCompanyID");
            }
        }

        [Required]
        [StringLength(30)]
        public string UserFirstName
        {
            get { return _user.UserFirstName; }
            set
            {
                _user.UserFirstName = value;
                RaisePropertyChanged("UserFirstName");
            }
        }

        [Required]
        [StringLength(30)]
        public string UserLastName
        {
            get { return _user.UserLastName; }
            set
            {
                _user.UserLastName = value;
                RaisePropertyChanged("UserLastName");
            }
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string UserEmail
        {
            get { return _user.UserEmail; }
            set
            {
                _user.UserEmail = value;
                RaisePropertyChanged("UserEmail");
            }
        }

        [Required]
        public string UserPassword
        {
            get { return _user.UserPassword; }
            set
            {
                _user.UserPassword = value;
                RaisePropertyChanged("UserPassword");
            }
        }

        public ICollection<Inspection> Inspections
        {
            get { return _user.Inspections; }
            set
            {
                _user.Inspections = value;
                RaisePropertyChanged("Inspections");
            }
        }

        public ICollection<Template> Templates
        {
            get { return _user.Templates; }
            set
            {
                _user.Templates = value;
                RaisePropertyChanged("Templates");
            }
        }

        public ICollection<UserRole> UserRoles
        {
            get { return _user.UserRoles; }
            set
            {
                _user.UserRoles = value;
                RaisePropertyChanged("UserRoles");
            }
        }
    }
}
