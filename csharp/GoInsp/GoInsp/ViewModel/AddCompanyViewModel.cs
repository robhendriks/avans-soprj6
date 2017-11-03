using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class AddCompanyViewModel
    {
        private ViewModelLocator vml;
        private CompaniesViewModel qvm;

        public ICommand AddCompanyCommand;

        public AddCompanyViewModel()
        {
            vml = new ViewModelLocator();
            qvm = vml.Companies;
            AddCompanyCommand = new RelayCommand(AddCompany);
        }


        public void AddCompany()
        {

        }
    }
}
