using FlexMenu;
using FlexMenu.Utility;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Utility.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using GoInsp.Core.Repository.Generic;

namespace GoInsp.ViewModel
{
    public class ManagementDashboardViewModel : BaseViewModel
    {
        private InspectionRepository inspRep;
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }

        public ObservableCollection<InspectionPerMonth> InspectionsPerMonth { get; set; }


        public ManagementDashboardViewModel()
        {
            Sheets = new Sheets() { UriBase = "Pages", Default = "Statistics" };
            Sheets["Statistics"] = "StatisticsPage";
            Sheets.GoToDefault();

            Populate();
        }

        public Sheets Sheets
        {
            get;
            set;
        }

        private void Populate()
        {
            inspRep = new InspectionRepository();
            //IEnumerable<Inspection> inspections = Context.Inspections;
            //IEnumerable<InspectionViewModel> inspectionsVM = inspections
            //   .Select(o => new InspectionViewModel(o));

            //Inspections = new ObservableCollection<InspectionViewModel>(inspectionsVM);
            //RaisePropertyChanged("Inspections");


            //INSPECTIES PER MAAND
            InspectionsPerMonth = new ObservableCollection<InspectionPerMonth>();

            IEnumerable<KeyValuePair<Int32, Int32>> query = inspRep.GetInspectionsPerMonth();

            string[] months = new string[12] { "Januari", "februari" , "Maart", "April" , "Mei" , "Juni" , "Juli" , "Augustus" , "September" , "Oktober" , "November", "December" };
            foreach (var t in query)
            {
                InspectionsPerMonth.Add(new InspectionPerMonth() { Maand = months[t.Key - 1], Count = t.Value});
            }
            //END INSPECTIES PER MAAND

            //AANTAL INSPECTIES PER INSPECTEUR

            //END AANTAL INSPECTIES PER INSPECTEUR


        }

        private object selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                // selected item has changed
                selectedItem = value;
            }
        }
    }
}
