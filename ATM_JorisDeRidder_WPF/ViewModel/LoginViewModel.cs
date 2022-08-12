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
using ATM_JorisDeRidder_WPF.View;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public string ClientEmail { get; set; }
        public string Password { get; set; }
        public string? foutmelding { get; set; }

        private Client selectedClient;

        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
            }
        }

        public LoginViewModel(int? clientID = null)
        {
            if (ClientID != null)
            {
                Client = unitOfWork.ClientRepo.Ophalen(c => c.ClientID == clientID).SingleOrDefault();
            }
            else
            {
                Client = new Client();
            }
        }

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
            var client = unitOfWork.ClientRepo.Ophalen(x => x.ClientEmail == Client.ClientEmail).SingleOrDefault();

            if (client == null)
            {
                foutmelding = "There is no account that has this password and or username";
                return;
            }

            if (Client.ClientEmail == client.ClientEmail)
            {
                if (Client.Password == client.Password)
                {
                    if (client.IsAdmin == false)
                    {
                        RefreshData();
                        OpenAccountWindow();
                    }
                    else
                    {
                        MessageBox.Show($"You are now logged in As ADMIN", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        RefreshData();
                        openAdminWindow();
                    }
                }
                else
                {
                    foutmelding = "Email or password doesn't match";
                }
            }
            else
            {
                foutmelding = "Email or password doesn't match";
            }
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel(selectedClient.ClientID);
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        public void OpenAccountWindow()
        {
            AccountViewModel aViewModel = new AccountViewModel(selectedClient.ClientID);
            View.AccountView aView = new View.AccountView();
            aView.DataContext = aViewModel;
            aView.Show();
        }

        public void openAdminWindow()
        {
            AdminViewModel adminViewModel = new AdminViewModel(selectedClient.ClientID);
            View.AdminView adminView = new View.AdminView();
            adminView.DataContext = adminViewModel;
            adminView.Show();
        }

        public void RefreshData()
        {
            unitOfWork.ClientRepo.Ophalen();
        }
    }
}