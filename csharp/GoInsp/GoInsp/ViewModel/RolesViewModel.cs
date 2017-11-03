using FlexAuth.Input;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Core.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class RolesViewModel : BaseViewModel
    {
        #region Repository

        private RoleRepository repo = new RoleRepository();

        private RoleViewModel _selectedItem;
        private NodeViewModel _selectedNodeIncluded;
        private NodeViewModel _selectedNodeExcluded;

        private string _query;

        #endregion


        #region Constructors

        public RolesViewModel()
        {
            Initialize();
            PopulateRoles();
        }

        #endregion


        #region Properties

        public ObservableCollection<RoleViewModel> Roles
        {
            get;
            set;
        }

        public ObservableCollection<NodeViewModel> NodesIncluded
        {
            get;
            set;
        }

        public ObservableCollection<NodeViewModel> NodesExcluded
        {
            get;
            set;
        }

        public RoleViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PopulateNodes(value == null);
                RaisePropertyChanged("SelectedItem");
            }
        }

        public NodeViewModel SelectedNodeIncluded
        {
            get { return _selectedNodeIncluded; }
            set
            {
                _selectedNodeIncluded = value;
                RaisePropertyChanged("SelectedNodeIncluded");
            }
        }

        public NodeViewModel SelectedNodeExcluded
        {
            get { return _selectedNodeExcluded; }
            set
            {
                _selectedNodeExcluded = value;
                RaisePropertyChanged("SelectedNodeExcluded");
            }
        }

        public string Query
        {
            get { return _query; }
            set
            {
                // TODO: Search

                RaisePropertyChanged("Query");
            }
        }

        public ICommand InsertRole { get; set; }
        public ICommand UpdateRole { get; set; }
        public ICommand DeleteRole { get; set; }
        public ICommand IncludeNode { get; set; }
        public ICommand ExcludeNode { get; set; }

        #endregion


        #region Methods

        private void Initialize()
        {
            InsertRole = new RelayCommand(OnInsertRole);
            UpdateRole = new RelayCommand(OnUpdateRole);
            DeleteRole = new RelayCommand(OnDeleteRole);
            IncludeNode = new RelayCommand(OnIncludeNode);
            ExcludeNode = new RelayCommand(OnExcludeNode);
        }

        private void PopulateRoles()
        {
            var roles = repo.GetAll();
            var roleVMs = roles
                .Select(o => new RoleViewModel(o));

            if (!string.IsNullOrEmpty(Query))
                roleVMs = roleVMs.Where(o => o.RoleName.ToLower().Contains(Query.ToLower()));

            Roles = new ObservableCollection<RoleViewModel>(roleVMs);
            RaisePropertyChanged("Roles");
        }

        private void PopulateNodes(bool empty = false)
        {
            // Populate included nodes
            PopulateNodesIncluded(empty);

            // Populate excluded nodes
            PopulateNodesExcluded(empty);
        }

        private void PopulateNodesIncluded(bool empty = false)
        {
            if (SelectedItem != null && !empty)
            {
                var roleNodes = SelectedItem.RoleNodes;
                var nodeVMs = roleNodes
                    .Select(o => new NodeViewModel(o.Node));

                NodesIncluded = new ObservableCollection<NodeViewModel>(nodeVMs);
            }
            else if(empty)
                NodesIncluded = null;

            RaisePropertyChanged("NodesIncluded");
        }

        private void PopulateNodesExcluded(bool empty = false)
        {
            if (SelectedItem != null && !empty)
            {
                var roleNodes = SelectedItem.RoleNodes;
                var nodeVMs = roleNodes
                    .Select(o => new NodeViewModel(o.Node))
                    .Where(o => !NodesIncluded.Contains(o));

                NodesExcluded = new ObservableCollection<NodeViewModel>(nodeVMs);
            }
            else if(empty)
                NodesExcluded = null;

            RaisePropertyChanged("NodesExcluded");
        }

        #endregion


        #region Methods

        public void OnInsertRole()
        {
            // TODO
        }

        public void OnUpdateRole()
        {
            // TODO
        }

        public void OnDeleteRole()
        {
            // TODO
        }

        public void OnIncludeNode()
        {
            // TODO
        }

        public void OnExcludeNode()
        {
            // TODO
        }

        #endregion

        //public RolesViewModel()
        //    : base()
        //{
        //    Populate();
        //    ChangeToAvailable = new AuthCommand(OnChangeToAvailable, "Hello");
        //    ChangeToUsed = new AuthCommand(OnChangeToUsed, "World");

        //    ChangeToAddMode = new AuthCommand(ToggleLightboxOn);
        //    SaveRole = new AuthCommand(SaveCurrentRole);
        //    DeleteRole = new AuthCommand(DeleteCurrentRole);

        //    AddRole = new AuthCommand(AddNewRole);
        //    StopAddingRole = new AuthCommand(ToggleLightBoxOff);
        //}

        //protected void OnChangeToAvailable()
        //{
        //    var tmp = SelectedUsedNode;

        //    if(tmp == null)
        //    {
        //        MessageBox.Show("Selecteer a.u.b. een item");
        //        return;
        //    }

        //    var roleNode = GetByRoleIDAndNodeID(
        //        SelectedItem.RoleID,
        //        SelectedUsedNode.NodeID);

        //    if (roleNode != null)
        //    {
        //        Context.RoleNodes.Remove(roleNode);
        //        Context.SaveChanges();

        //        AvailableNodes.Add(_selectedUsedNode);
        //        RaisePropertyChanged("AvailableNodes");

        //        UsedNodes.Remove(_selectedUsedNode);
        //        RaisePropertyChanged("UsedNodes");
        //    }
        //    else
        //        MessageBox.Show("Onverwachte fout");
        //}

        //protected void OnChangeToUsed()
        //{
        //    var tmp = SelectedAvailableNode;

        //    if (tmp == null)
        //    {
        //        MessageBox.Show("Selecteer a.u.b. een item");
        //        return;
        //    }

        //    var roleNode = new RoleNode()
        //    {
        //        RoleID = _selectedItem.RoleID,
        //        NodeID = _selectedAvailableNode.NodeID
        //    };

        //    Context.RoleNodes.Add(roleNode);
        //    Context.SaveChanges();

        //    UsedNodes.Add(_selectedAvailableNode);
        //    RaisePropertyChanged("UsedNodes");

        //    AvailableNodes.Remove(_selectedAvailableNode);
        //    RaisePropertyChanged("AvailableNodes");
        //}

        //private RoleNode GetByRoleIDAndNodeID(long roleID, long nodeID)
        //{
        //    IEnumerable<RoleNode> roleNodes = Context.RoleNodes;
        //    return roleNodes
        //        .Where(o => o.RoleID.Equals(roleID))
        //        .Where(o => o.NodeID.Equals(nodeID))
        //        .SingleOrDefault();
        //}

        //public void AddNewRole()
        //{
        //    if (SelectedItem.RoleName != null && SelectedItem.RoleDescription != null)
        //    {
        //        SelectedItem.Role.RoleName = SelectedItem.RoleName;
        //        SelectedItem.Role.RoleDescription = SelectedItem.RoleDescription;

        //        Context.Roles.Add(SelectedItem.Role);

        //        Roles.Add(SelectedItem);
        //        Context.SaveChanges();
        //        ToggleLightBoxOff();
        //    }
        //    else
        //        MessageBox.Show("Selecteer a.u.b. een rol naam en rol beschrijving");
        //}

        //public void SaveCurrentRole()
        //{
        //    if (SelectedItem != null)
        //    {
        //        if (SelectedItem.RoleName != null && SelectedItem.RoleDescription != null)
        //            Context.SaveChanges();
        //    }
        //}


        //public void DeleteCurrentRole()
        //{
        //    if(SelectedItem != null && SelectedItem.GetType() == typeof(RoleViewModel)) { 
        //        Context.Roles.Remove(SelectedItem.Role);
        //        IEnumerable<RoleNode> rolenodes = Context.RoleNodes;
        //        foreach (RoleNode r in rolenodes)
        //        {
        //            if (r.RoleID == SelectedItem.RoleID)
        //                Context.RoleNodes.Remove(r);
        //        }

        //        IEnumerable<UserRole> userroles = Context.UserRoles;
        //        foreach (UserRole u in userroles)
        //        {
        //            if (u.RoleID == SelectedItem.RoleID)
        //                Context.UserRoles.Remove(u);
        //        }
        //        Context.SaveChanges();
        //        Roles.Remove(SelectedItem);
        //    }
        //}

        //public void ToggleLightboxOn()
        //{
        //    FlexMenuManager.Instance.OpenLightbox();
        //    SelectedItem = new RoleViewModel();
        //}

        //public void ToggleLightBoxOff()
        //{
        //    FlexMenuManager.Instance.CloseLightbox();
        //}
    }
}
