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
        public ICollection<Client> Clients { get; set; }
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
                if (columnName == "Password" && string.IsNullOrWhiteSpace(Password))
                {
                    return "Password is required! ";
                }
                if (columnName == "ClientName" && string.IsNullOrWhiteSpace(ClientName))
                {
                    return "ClientName is required! ";
                }
                if (columnName == "ClientEmail" && string.IsNullOrWhiteSpace(ClientEmail))
                {
                    return "Email is required! ";
                }
                if (columnName == "ConfirmPassword" && ConfirmPassword != Password)
                {
                    return "Confirmpassword needs to be the same as password ";
                }
                if (columnName == "Country" && string.IsNullOrWhiteSpace(Country))
                {
                    return "Country is required! ";
                }
                if (columnName == "City" && string.IsNullOrWhiteSpace(City))
                {
                    return "City is required! ";
                }
                if (columnName == "Street" && string.IsNullOrWhiteSpace(Street))
                {
                    return "Street is required! ";
                }
                if (columnName == "HouseNumber" && string.IsNullOrWhiteSpace(HouseNumber))
                {
                    return "Housenumber is required! ";
                }
                if (columnName == "ZipCode" && string.IsNullOrWhiteSpace(ZipCode))
                {
                    return "ZipCode is required! ";
                }

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
            if (this.IsGeldig())
            {
                Client client = new Client()
                {
                    ClientName = ClientName,
                    ClientEmail = ClientEmail,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword,
                    Country = Country,
                    City = City,
                    Street = Street,
                    HouseNumber = HouseNumber,
                    ZipCode = ZipCode,
                    IsAdmin = false,
                    BirthDate = BirthDate
                };
                var clientCheck = unitOfWork.ClientRepo.Ophalen(c => c.ClientID == Session.SelectedClientId).SingleOrDefault();

                if (clientCheck == null)
                {
                    unitOfWork.ClientRepo.Toevoegen(client);
                    unitOfWork.Save();
                    RefreshData();

                    MessageBox.Show("Your account is created", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    OpenLoginWindow();
                }
                else
                {
                    Foutmelding = "This account already exists";
                }
            }
            else
            {
                Foutmelding = Error;
            }
        }

        public void GoBack()
        {
            LoginViewModel viewModel = new LoginViewModel();
            View.LoginView view = new View.LoginView();
            view.DataContext = viewModel;
            view.Show();
        }

        public void OpenLoginWindow()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lview = new View.LoginView();
            lview.DataContext = lviewModel;
            lview.Show();
        }

        private void RefreshData()
        {
            Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen(c => c.ClientID == Session.SelectedClientId));
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}