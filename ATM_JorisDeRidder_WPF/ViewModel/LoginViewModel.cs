using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel
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
                case "Register": OpenRegisterPage(); break;
                case "Login": Login(); break;
            }
        }

        private void Login()
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            View.AccountView accountView = new View.AccountView();
            accountView.DataContext = accountViewModel;
            accountView.Show();
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