using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using System.Collections.Generic;

namespace GoInsp.ViewModel
{
    public class RoleViewModel : ViewModelBase
    {
        #region Fields

        private Role _poco;

        #endregion


        #region Constructors

        public RoleViewModel(Role poco = null)
        {
            _poco = poco ?? new Role();
        }

        #endregion


        #region Properties

        public Role Poco
        {
            get { return _poco; }
        }


        public int RoleID
        {
            get { return _poco.RoleID; }
            set
            {
                _poco.RoleID = value;
                RaisePropertyChanged("RoleID");
            }
        }

        public string RoleName
        {
            get { return _poco.RoleName; }
            set
            {
                _poco.RoleName = value;
                RaisePropertyChanged("RoleName");
            }
        }

        public string RoleDescription
        {
            get { return _poco.RoleDescription; }
            set
            {
                _poco.RoleDescription = value;
                RaisePropertyChanged("RoleDescription");
            }
        }

        public bool? RoleDefaultFlag
        {
            get { return _poco.RoleDefaultFlag; }
            set
            {
                _poco.RoleDefaultFlag = value;
                RaisePropertyChanged("RoleDefaultFlag");
            }
        }

        public ICollection<RoleNode> RoleNodes
        {
            get { return _poco.RoleNodes; }
            set
            {
                _poco.RoleNodes = value;
                RaisePropertyChanged("RoleNodes");
            }
        }

        public ICollection<UserRole> UserRoles
        {
            get { return _poco.UserRoles; }
            set
            {
                _poco.UserRoles = value;
                RaisePropertyChanged("UserRoles");
            }
        }

        #endregion
    }
}
