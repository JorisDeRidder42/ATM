using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using ATM_JorisDeRidder_Model;
using ATM_JorisDeRidder_WPF.View;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public int ClientID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Foutmelding { get; set; }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register": OpenRegisterPage(); break;
                case "Login": OpenLogin(); break;
            }
        }

        public void OpenLogin()
        {
            var clientCheck = unitOfWork.ClientRepo.Ophalen(x => x.ClientEmail == Email).SingleOrDefault();

            if (clientCheck == null)
            {
                Foutmelding = "There is no account that has this password and or username";
                return;
            }

            if (Email == clientCheck.ClientEmail && Password == clientCheck.Password)
            {
                if (clientCheck.IsAdmin == false)
                {
                    Session.SelectedClientId = clientCheck.ClientID;
                    OpenAccountWindow();
                }
                else
                {
                    MessageBox.Show($"You are now logged in As ADMIN", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    openAdminWindow();
                }
            }
            else
            {
                Foutmelding = "Email or password doesn't match";
            }
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }

        public void OpenAccountWindow()
        {
            //AccountViewModel aViewModel = new AccountViewModel();
            //View.AccountView aView = new View.AccountView();
            //aView.DataContext = aViewModel;
            //aView.Show();

            CardViewModel cardViewModel = new CardViewModel();
            View.CardView cardView = new View.CardView();
            cardView.DataContext = cardViewModel;
            cardView.Show();
        }

        public void openAdminWindow()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            View.AdminView adminView = new View.AdminView();
            adminView.DataContext = adminViewModel;
            adminView.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}