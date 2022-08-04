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
        public string? ClientEmail { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public string? foutmelding { get; set; }
        public Client? Client { get; set; }
        public ObservableCollection<Client>? Clients { get; set; }

        public LoginViewModel()
        {
            if (ClientID != null)
            {
                Client = unitOfWork.ClientRepo.Ophalen(c => c.ClientID).SingleOrDefault();
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
                case "Account": CreateAccount(); break;
            }
        }

        private void CreateAccount()
        {
            throw new NotImplementedException();
        }

        public void OpenLogin()
        {
            var client = unitOfWork.ClientRepo.Ophalen(x => x.ClientEmail == Client.ClientEmail).SingleOrDefault();

            if (client == null)
            {
                MessageBox.Show("Error");
                return;
            }

            if (Client.ClientEmail == client.ClientEmail)
            {
                if (Client.Password == client.Password)
                {
                    if (client.IsAdmin == false)
                    {
                        unitOfWork.ClientRepo.Ophalen();
                        OpenActionWindow();
                    }
                    else
                    {
                        MessageBox.Show($"You are now logged in As ADMIN", "Information");
                        unitOfWork.ClientRepo.Ophalen();
                        openAdminWindow();
                    }
                }
                else
                {
                    MessageBox.Show("Email or password dont match");
                }
            }
            else
            {
                MessageBox.Show("Email or password dont match");
            }
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        public void OpenActionWindow()
        {
            ActionViewModel actionViewModel = new ActionViewModel();
            View.ActionView actionView = new View.ActionView();
            actionView.DataContext = actionViewModel;
            actionView.Show();
        }

        public void openAdminWindow()
        {
            AdminViewModel adminViewModel = new AdminViewModel();
            View.AdminView adminView = new View.AdminView();
            adminView.DataContext = adminViewModel;
            adminView.Show();
        }
    }
}