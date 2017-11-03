using FlexAuth.Security;
using GalaSoft.MvvmLight.Command;
using GoInsp.Core.Model;
using GoInsp.Security;
using System;
using System.Windows;
using System.Windows.Input;

namespace GoInsp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Constructors

        public LoginViewModel()
            : base()
        {
            SignIn = new RelayCommand(OnSignIn);
        }

        #endregion


        #region Properties

        public ICommand SignIn { get; set; }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }


        #endregion


        #region Methods

        protected void OnSignIn()
        {
            if (String.IsNullOrEmpty(Email))
                MessageBox.Show("Voer a.u.b. een e-mailadres in.");
            else if (String.IsNullOrEmpty(Password))
                MessageBox.Show("Voer a.u.b. uw wachtwoord in.");
            else
            {
                try
                {
                    var user = new GoInspUser();
                    user.Credentials = new GoInspCredentials()
                    {
                        Email = Email,
                        Password = Password
                    };
                    user.SignIn();
                    var poco = user.Convert<User>();

                    MessageBox.Show(String.Format("{0} {1} werkzaam bij {2}"
                            , poco?.UserFirstName
                            , poco?.UserLastName
                            , poco?.Company.CompanyName));
                }
                catch (SignInException e)
                {
                    string message;

                    switch (e.ErrorCode)
                    {
                        default: message = e.Message; break;
                        case 101: message = "Deze gebruiker is al ingelogd"; break;
                        case 103: message = "E-mailadres en/of wachtwoord onjuist"; break;
                    }

                    MessageBox.Show(message, "Inloggen mislukt");
                }
            }
        }

        #endregion
    }
}
