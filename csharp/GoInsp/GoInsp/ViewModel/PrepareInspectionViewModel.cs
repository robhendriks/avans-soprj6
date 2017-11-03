using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Core.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class PrepareInspectionViewModel : BaseViewModel
    {
        // Bindings
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }
        public ObservableCollection<UserViewModel> Users { get; set; }
        public Boolean isEnabled { get; set; }
        public Double opacity { get; set; }

        InspectionRepository Repo = new InspectionRepository();

        // Commands
        public ICommand PrepareInspectionCommand { get; set; }

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

        public PrepareInspectionViewModel()
            : base()
        {
            isEnabled = false;
            opacity = 0.7;
            PrepareInspectionCommand = new RelayCommand(InspectionCheck);
            Populate();
        }

        public void Populate()
        {
            // Inspections
            IEnumerable<Inspection> inspections = Repo.GetAll();
            IEnumerable<InspectionViewModel> inspectionVM = inspections
                .Select(i => new InspectionViewModel(i));

            Inspections = new ObservableCollection<InspectionViewModel>(inspectionVM);
        }

        private void InspectionCheck()
        {
            
            if (SelectedItem != null)
            {
                isEnabled = true;
                opacity = 1;
                RaisePropertyChanged("isEnabled");
                RaisePropertyChanged("opacity");
            }
            else
            {
                isEnabled = false;
                opacity = 0.7;
                RaisePropertyChanged("isEnabled");
                RaisePropertyChanged("opacity");
            }
        }
    }
}
