using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class HomeViewModel : BasisViewModel
    {
        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            //returnwaarde true -> methode mag uitgevoerd worden
            //returnwaarde false -> methode mag niet uitgevoerd worden
            switch (parameter.ToString())
            {
                case "Register": return true;
                case "Login": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            //Via parameter kom je te weten op welke knop er gedrukt is,
            //instelling via CommandParameter in xaml
            switch (parameter.ToString())
            {
                case "Register": OpenRegisterPage(); break;
                case "Login": OpenLoginPage(); break;
            }
        }

        private void OpenLoginPage()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            View.LoginView loginview = new View.LoginView();
            loginview.DataContext = loginViewModel;
            loginview.Show();
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }
    }
}