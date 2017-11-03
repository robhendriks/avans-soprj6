using GalaSoft.MvvmLight;
using GoInsp.Core.Model;
using System;
using System.Collections.Generic;

namespace GoInsp.ViewModel
{
    public class InspectionViewModel : ViewModelBase
    {
        private Inspection _inspection;
        public Inspection Inspection
        {
            get { return _inspection; }
        }

        public InspectionViewModel()
        {
            _inspection = new Inspection();
        }

        public InspectionViewModel(Inspection inspection)
        {
            _inspection = inspection ?? new Inspection();
        }

        public Guid InspectionID
        {
            get { return _inspection.InspectionID; }
            set
            {
                _inspection.InspectionID = value;
                RaisePropertyChanged("InspectionID");
            }
        }

        public int? InspectionUserID
        {
            get { return _inspection.InspectionUserID; }
            set
            {
                _inspection.InspectionUserID = value;
                RaisePropertyChanged("InspectionUserID");
            }
        }

        public int? InspectionCompanyID
        {
            get { return _inspection.InspectionCompanyID; }
            set
            {
                _inspection.InspectionCompanyID = value;
                RaisePropertyChanged("InspectionCompanyID");
            }
        }

        public Company Company
        {
            get { return _inspection.Company; }
            set
            {
                _inspection.Company = value;
                RaisePropertyChanged("Company");
            }
        }

        public User User
        {
            get { return _inspection.User; }
            set
            {
                _inspection.User = value;
                RaisePropertyChanged("User");
            }
        }

        public string InspectionTitle
        {
            get { return _inspection.InspectionTitle; }
            set
            {
                _inspection.InspectionTitle = value;
                RaisePropertyChanged("InspectionTitle");
            }
        }

        public DateTime? InspectionStartTime
        {
            get { return _inspection.InspectionStartTime; }
            set
            {
                _inspection.InspectionStartTime = value;
                RaisePropertyChanged("InspectionStartTime");
            }
        }

        public DateTime? InspectionEndTime
        {
            get { return _inspection.InspectionEndTime; }
            set
            {
                _inspection.InspectionEndTime = value;
                RaisePropertyChanged("InspectionEndTime");
            }
        }
    }
}
