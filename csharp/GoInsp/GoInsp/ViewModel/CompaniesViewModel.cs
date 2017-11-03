using FlexAuth.Input;
using FlexMenu;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core;
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
    public class CompaniesViewModel : BaseViewModel
    {
        public ObservableCollection<CompanyViewModel> Companies { get; set; }
        private CompanyRepository Repo { get; set; }

        private CompanyViewModel _selectedItem;
        public CompanyViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        private string _query;
        public string Query
        {
            get { return _query; }
            set
            {
                _query = (String.IsNullOrEmpty(value) ? null : value);

                SelectedItem = null;

                PopulateCompanies();
                RaisePropertyChanged("Query");
            }
        }

        public ICommand SaveChanges { get; set; }
        public ICommand DeleteCompany { get; set; }
        public ICommand CreateCompany { get; set; }

        public ICommand ToggleOn { get; set; }
        public ICommand ToggleOff { get; set; }
        

        public CompaniesViewModel()
            : base()
        {
            /* ---- Companies ---- */
            Repo = new CompanyRepository();
            PopulateCompanies();

            SaveChanges = new AuthCommand(SaveCurrentChanges);
            DeleteCompany = new AuthCommand(DeleteSelectedCompany);
            CreateCompany = new AuthCommand(CreateNewCompany);
            ToggleOn = new AuthCommand(ToggleLightboxOn);
            ToggleOff = new AuthCommand(ToggleLightBoxOff);
        }

        public void PopulateCompanies()
        {


            IEnumerable<Company> companies = Repo.GetAll();
            IEnumerable<CompanyViewModel> companyVM = companies
               .Select(o => new CompanyViewModel(o));

            if (_query != null)
                companyVM = companyVM
                    .Where(o => o.CompanyName.ToLower().Contains(_query.ToLower()));

            Companies = new ObservableCollection<CompanyViewModel>(companyVM);
            RaisePropertyChanged("Companies");
        }

        public void SaveCurrentChanges()
        {
            if (SelectedItem != null)
                if (SelectedItem.CompanyName != null && SelectedItem.CompanyEmail != null && ValidateFields())
                {
                    MessageBox.Show("Opgeslagen");
                    Repo.Save();
                }
        }

        public void DeleteSelectedCompany()
        {
            if(SelectedItem != null)
            {
                if (SelectedItem.CompanyDefaultFlag == true)
                {
                    MessageBox.Show("Deze mag niet verwijderd worden");
                    return;
                }

                Repo.Delete(SelectedItem.CompanyID);
                Repo.Save();

                Companies.Remove(SelectedItem);
                MessageBox.Show("verwijderd");
            }
            else
            {
                MessageBox.Show("Geen bedrijf geselecteerd");
            }
        }

        public void CreateNewCompany()
        {
            if (string.IsNullOrEmpty(SelectedItem.CompanyName))
            {
                MessageBox.Show("Vul a.u.b. een Bedrijfsaam in");
                return;
            }
            if (string.IsNullOrEmpty(SelectedItem.CompanyEmail))
            {
                MessageBox.Show("Vul a.u.b. een Bedrijfsemail in");
                return;
            }

            if (!ValidateFields())
            {
                return;
            }


            // Required
            SelectedItem.Company.CompanyName = SelectedItem.CompanyName;
            SelectedItem.Company.CompanyEmail = SelectedItem.CompanyEmail;
            SelectedItem.Company.CompanyID = SelectedItem.CompanyID;

            // Optional
            SelectedItem.Company.CompanyAddress = SelectedItem.CompanyAddress;
            SelectedItem.Company.CompanyCity = SelectedItem.CompanyCity;
            SelectedItem.Company.CompanyPhone = SelectedItem.CompanyPhone;
            SelectedItem.Company.CompanyZip = SelectedItem.CompanyZip;

            Repo.Insert(SelectedItem.Company);
            Repo.Save();

            Companies.Add(SelectedItem);
            
            RaisePropertyChanged("Companies");
            MessageBox.Show("Bedrijf '" + SelectedItem.CompanyName + "' is toegevoegd");

            ToggleLightBoxOff();
        }

        public void ToggleLightboxOn()
        {
            FlexMenuManager.Instance.OpenLightbox();
            SelectedItem = new CompanyViewModel();
        }

        public void ToggleLightBoxOff()
        {
            FlexMenuManager.Instance.CloseLightbox();
        }

        public bool  ValidateFields()
        {
            if (!string.IsNullOrEmpty(SelectedItem.CompanyZip))
                if (SelectedItem.CompanyZip.Length > 10)
                {
                    MessageBox.Show("postcode ongeldig!");
                    return false;
                }
            if (!string.IsNullOrEmpty(SelectedItem.CompanyPhone))
                if (SelectedItem.CompanyPhone.Length > 20)
                {
                    MessageBox.Show("telefoonnummer ongeldig!");
                    return false;
                }
            if (!string.IsNullOrEmpty(SelectedItem.CompanyName))
                if (SelectedItem.CompanyName.Length > 30)
                {
                    MessageBox.Show("Naam te lang!");
                    return false;
                }
            if (!string.IsNullOrEmpty(SelectedItem.CompanyAddress))
                if (SelectedItem.CompanyAddress.Length > 50)
                {
                    MessageBox.Show("Adres te lang!");
                    return false;
                }
            if (!string.IsNullOrEmpty(SelectedItem.CompanyCity))
                if (SelectedItem.CompanyCity.Length > 30)
                {
                    MessageBox.Show("Stadnaam te lang!");
                    return false;
                }

            return true;
        }
    }
}