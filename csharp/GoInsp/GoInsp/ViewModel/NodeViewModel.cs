using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using System.Collections.Generic;

namespace GoInsp.ViewModel
{
    public class NodeViewModel : ViewModelBase
    {
        #region Fields

        private Node _poco;

        #endregion


        #region Constructors

        public NodeViewModel(Node poco = null)
        {
            _poco = poco ?? new Node();
        }

        #endregion


        #region Properties

        public Node Poco
        {
            get { return _poco; }
        }


        public int NodeID
        {
            get { return _poco.NodeID; }
            set
            {
                _poco.NodeID = value;
                RaisePropertyChanged("RoleID");
            }
        }

        public string NodeName
        {
            get { return _poco.NodeName; }
            set
            {
                _poco.NodeName = value;
                RaisePropertyChanged("RoleName");
            }
        }

        public bool? NodeDefaultFlag
        {
            get { return _poco.NodeDefaultFlag; }
            set
            {
                _poco.NodeDefaultFlag = value;
                RaisePropertyChanged("NodeDefaultFlag");
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

        #endregion
    }
}
