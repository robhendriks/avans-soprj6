using GalaSoft.MvvmLight.Command;
using GoInsp.Utility.Navigation;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{

    public class DashboardViewModel : BaseViewModel
    {
        #region Constructors

        public DashboardViewModel()
        {
            Sheets = new Sheets() { UriBase = "Pages", Default = "Dashboard" };
            Sheets["Administration"] = "AdministrationPage";
            Sheets["Dashboard"] = "DashboardPage";
            Sheets["Inspect"] = "InspectPage";
            Sheets.GoToDefault();
        }

        #endregion


        #region Properties

        public Sheets Sheets
        {
            get;
            set;
        }

        #endregion
    }
}
