using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using ATM_JorisDeRidder_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class RegisterViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public Client? Client { get; set; }
        public int? ClientID { get; set; }
        public string? Foutmelding { get; set; }
        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public bool? IsAdmin { get; set; }
        public string? BirthDate { get; set; }

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
                case "Register": Register(); break;
                case "Back": GoBack(); break;
            }
        }

        public void Register()
        {
            Client client = new Client();
            var clientCheck = unitOfWork.ClientRepo.Ophalen().SingleOrDefault();

            if (clientCheck == null)
            {
                if (client.Password == clientCheck.Password)
                {
                    unitOfWork.ClientRepo.Toevoegen(client);
                    unitOfWork.Save();
                    RefreshData();

                    MessageBox.Show("Your account is created", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    OpenLoginWindow();
                }
                else
                {
                    Foutmelding = "Please fill in the form";
                }
            }
            else
            {
                Foutmelding = "This account already exists";
            }
        }

        public void GoBack()
        {
            LoginViewModel viewModel = new LoginViewModel();
            View.LoginView view = new View.LoginView();
            Session.ClosePreviousWindow(view);
            view.DataContext = viewModel;
            view.Show();
        }

        public void OpenLoginWindow()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lview = new View.LoginView();
            Session.ClosePreviousWindow(lview);
            lview.DataContext = lviewModel;
            lview.Show();
        }

        private void RefreshData()
        {
            Client = unitOfWork.ClientRepo.Ophalen(c => c.ClientID).SingleOrDefault();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}