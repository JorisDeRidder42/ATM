using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public string? Password { get; set; }
        public string? ClientName { get; set; }
        public bool? IsAdmin { get; set; }
        public string? foutmelding { get; set; }
        public Client? Client { get; set; }
        public ObservableCollection<Client> Clients { get; set; }

        public LoginViewModel()
        {
            Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
        }

        public override string this[string columnName] => "";

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
            OpenActionWindow();
            //var clientName = unitOfWork.ClientRepo.Ophalen(x => x.ClientName == Client.ClientName).LastOrDefault();
            //var clientAdmin = unitOfWork.ClientRepo.Ophalen(x => x.IsAdmin == Client.IsAdmin).SingleOrDefault();
            //var clientPassword = unitOfWork.ClientRepo.Ophalen(x => x.Password == Client.Password).SingleOrDefault();

            //if (Client.ClientName != null)
            //{
            //    if (Client.ClientName == clientName.ClientName)
            //    {
            //        if (Client.Password == clientPassword.Password)
            //        {
            //            if (Client.IsAdmin == false && clientAdmin.IsAdmin == false)
            //            {
            //                OpenActionWindow();
            //                unitOfWork.ClientRepo.Ophalen();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Username or password doesn't match");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Username or password doesn't match");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("You first needs to register");
            //}
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
            unitOfWork.Dispose();
        }

        public void OpenActionWindow()
        {
            //ActionViewModel actionViewModel = new ActionViewModel();
            //View.ActionView actionView = new View.ActionView();
            //actionView.DataContext = actionViewModel;
            //actionView.Show();
            LogViewModel logViewModel = new LogViewModel();
            View.LogView logView = new View.LogView();
            logView.DataContext = logViewModel;
            logView.Show();
        }
    }
}