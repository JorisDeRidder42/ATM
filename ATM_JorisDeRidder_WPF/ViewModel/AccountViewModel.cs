using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.ObjectModel;
using ATM_JorisDeRidder_DAL;
using System.Windows;
using System.Linq;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class AccountViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public Account Account { get; set; }
        public Client Client { get; set; }
        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public string SelectedAccount { get; set; }
        public ObservableCollection<Client> Clients { get; set; }

        public AccountViewModel(int clientID)
        {
            //Client = unitOfWork.ClientRepo.Ophalen(x => x.ClientID == clientID, x => x.Accounts.Select(y => y.AccountName)).SingleOrDefault();
            Client = unitOfWork.ClientRepo.Ophalen(x => x.ClientID == clientID).SingleOrDefault();
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
                case "Go": OpenActionWindow(); break;
                case "Bill": CreateNewBill(); break;
                case "Back": Back(); break;
            }
        }

        private void CreateNewBill()
        {
            CreateAccountViewModel createAccountViewModel = new CreateAccountViewModel();
            View.CreateAccountView createAccountView = new View.CreateAccountView();
            createAccountView.DataContext = createAccountViewModel;
            createAccountView.Show();
        }

        public void OpenActionWindow()
        {
            if (SelectedAccount != null)
            {
                ActionViewModel actionViewModel = new ActionViewModel();
                View.ActionView actionView = new View.ActionView();
                actionView.DataContext = actionViewModel;
                actionView.Show();
            }
            else
            {
                MessageBox.Show("Select a bill first", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        private void Back()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lView = new View.LoginView();
            lView.DataContext = lviewModel;
            lView.Show();
        }
    }
}