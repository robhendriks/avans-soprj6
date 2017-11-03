using GalaSoft.MvvmLight;
using GoInsp.Core;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInsp.ViewModel
{
    public class CompanyViewModel : ViewModelBase
    {
        private Company _company;
        public Company Company
        {
            get { return _company; }
        }

        public CompanyViewModel()
        {
            _company = new Company();
        }

        public CompanyViewModel(Company company)
        {
            _company = company ?? new Company();
        }

        public int CompanyID
        {
            get { return _company.CompanyID; }
            set
            {
                _company.CompanyID = value;
                RaisePropertyChanged("CompanyID");
            }
        }

        public string CompanyName
        {
            get { return _company.CompanyName; }
            set
            {
                _company.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string CompanyEmail
        {
            get { return _company.CompanyEmail; }
            set
            {
                _company.CompanyEmail = value;
                RaisePropertyChanged("CompanyEmail");
            }
        }

        public string CompanyPhone
        {
            get { return _company.CompanyPhone; }
            set
            {
                _company.CompanyPhone = value;
                RaisePropertyChanged("CompanyPhone");
            }
        }

        public string CompanyAddress
        {
            get { return _company.CompanyAddress; }
            set
            {
                _company.CompanyAddress = value;
                RaisePropertyChanged("CompanyAddress");
            }
        }

        public string CompanyCity
        {
            get { return _company.CompanyCity; }
            set
            {
                _company.CompanyCity = value;
                RaisePropertyChanged("CompanyCity");
            }
        }

        public string CompanyZip
        {
            get { return _company.CompanyZip; }
            set
            {
                _company.CompanyZip = value;
                RaisePropertyChanged("CompanyZip");
            }
        }

        public bool? CompanyDefaultFlag
        {
            get { return _company.CompanyDefaultFlag; }
            set
            {
                _company.CompanyDefaultFlag = value;
                RaisePropertyChanged("CompanyDefaultFlag");
            }
        }
    }
}
