using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.ObjectModel;
using ATM_JorisDeRidder_DAL;
using System.Windows;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class AccountViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public ObservableCollection<Account>? Accounts { get; set; }
        public ObservableCollection<Client>? Clients { get; set; }

        public int AccountID { get; set; }
        public int ClientID { get; set; }

        public Account? AccountRecord { get; set; }

        private Account? _selectAccount;

        public Account? SelectedAccount
        {
            get { return _selectAccount; }
            set
            {
                _selectAccount = value;
                AccountSelecteren();
            }
        }

        public AccountViewModel()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen());
            //Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen(x => x.ClientID));
        }

        private void AccountSelecteren()
        {
            if (SelectedAccount != null)
            {
                AccountRecord = SelectedAccount;
            }
            else
            {
                AccountRecord = new Account();
            }
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

        public void OpenActionWindow(int? clientID = null)
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