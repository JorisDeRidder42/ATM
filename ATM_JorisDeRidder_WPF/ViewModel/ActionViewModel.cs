using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class ActionViewModel : BasisViewModel
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
                case "Logout": Logout(); break;
                case "Deposit": Deposit(); break;
            }
        }

        private void Deposit()
        {
            DepositViewModel depositViewModel = new DepositViewModel();
            View.DepositView depositView = new View.DepositView();
            depositView.DataContext = depositViewModel;
            depositView.Show();
        }

        private void Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            View.LoginView loginView = new View.LoginView();
            loginView.DataContext = loginViewModel;
            loginView.Show();
        }
    }
}