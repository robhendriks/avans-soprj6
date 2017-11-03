using FlexAuth.Input;
using FlexAuth.Security;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class InspectionsViewModel : BaseViewModel
    {
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }
        public ObservableCollection<CompanyViewModel> Companies { get; set; }
        public ObservableCollection<UserViewModel> Users { get; set; }
        // Todo: Create location VM and add collection here

        private string _query;
        public string Query
        {
            get { return _query; }
            set
            {
                _query = (String.IsNullOrEmpty(value) ? null : value);

                SelectedItem = null;

                Populate();
                RaisePropertyChanged("Query");
            }
        }

        private InspectionViewModel _selectedItem;
        public InspectionViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
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

        public ICommand ChangeToAddMode { get; set; }
        public ICommand SaveInspection { get; set; }
        public ICommand DeleteInspection { get; set; }

        public ICommand AddInspection { get; set; }
        public ICommand StopAddingInspection { get; set; }
        

        public InspectionsViewModel()
            : base()
        {
            PopulateCompanies();
            PopulateUsers();
            Populate();
            
            ChangeToAddMode = new AuthCommand(ChangeVisibility);
            SaveInspection = new AuthCommand(SaveCurrentInspection);
            DeleteInspection = new AuthCommand(DeleteCurrentInspection);

            AddInspection = new AuthCommand(AddNewInspection);
            StopAddingInspection = new AuthCommand(StopAddInspection);

            Visibility = "Hidden";
        }

        public void PopulateCompanies()
        {
            //IEnumerable<Company> companies = Context.Companies;
            //IEnumerable<CompanyViewModel> companiesVM = companies
            //   .Select(o => new CompanyViewModel(o));

            //Companies = new ObservableCollection<CompanyViewModel>(companiesVM);
            //RaisePropertyChanged("Companies");
        }

        public void PopulateUsers()
        {
            //IEnumerable<User> users = Context.Users;
            //IEnumerable<UserViewModel> usersVM = users
            //   .Select(o => new UserViewModel(o));

            //Users = new ObservableCollection<UserViewModel>(usersVM);
            //RaisePropertyChanged("Users");
        }

        public void Populate()
        {
            //IEnumerable<Inspection> inspections = Context.Inspections;
            //IEnumerable<InspectionViewModel> inspectionsVM = inspections
            //   .Select(o => new InspectionViewModel(o));

            ///*if (_query != null)
            //    inspectionsVM = inspectionsVM
            //        .Where(o => o.InspectionCompanyID.ToLower().Contains(_query.ToLower()));*/

            //Inspections = new ObservableCollection<InspectionViewModel>(inspectionsVM);
            //RaisePropertyChanged("Inspections");
        }

        public void AddNewInspection()
        {
            if (SelectedItem.InspectionCompanyID != 0)
            {
                //SelectedItem.Inspection.InspectionCompanyID = SelectedItem.InspectionCompanyID;

                //Context.Inspections.Add(SelectedItem.Inspection);

                //Inspections.Add(SelectedItem);
                //Context.SaveChanges();
                //ChangeVisibility();
            }
            else
                MessageBox.Show("Selecteer a.u.b. een bedrijf");
        }

        public void SaveCurrentInspection()
        {
            if (SelectedItem != null)
            {
                //if (SelectedItem.InspectionID != 0 && SelectedItem.InspectionCompanyID != 0)
                //    Context.SaveChanges();
            }
        }

        public void DeleteCurrentInspection()
        {
            if(SelectedItem != null && SelectedItem.GetType() == typeof(InspectionViewModel)) { 
                //Context.Inspections.Remove(SelectedItem.Inspection);
                //Inspections.Remove(SelectedItem);
                //Context.SaveChanges();
            }
        }

        public void ChangeVisibility()
        {
            if (Visibility.Equals("Visible"))
                Visibility = "Hidden";
            else
            {
                SelectedItem = new InspectionViewModel();
                Visibility = "Visible";
            }
        }

        public void StopAddInspection()
        {
            ChangeVisibility();
            SelectedItem = null;
        }
    }
}
