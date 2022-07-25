using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class RegisterViewModel : BasisViewModel
    {
        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Login": openLoginPage(); break;
                case "Back": goBack(); break;
            }
        }

        private void goBack()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            View.HomeView homeView = new View.HomeView();
            homeView.DataContext = homeViewModel;
            homeView.Show();
        }

        private void openLoginPage()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            View.LoginView loginView = new View.LoginView();
            loginView.DataContext = loginViewModel;
            loginView.Show();
        }
    }
}