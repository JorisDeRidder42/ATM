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
    public class ActionViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public int ClientID { get; set; }
        public Collection<Account> Accounts { get; set; }

        public Account SelectedAccount { get; set; }

        public override string this[string columnName] => "";

        public ActionViewModel()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen(x => x.ClientID == Session.SelectedItemId));
        }

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
                case "Withdraw": Withdraw(); break;
                case "Balance": Balance(); break;
                case "Delete": DeleteAccount(); break;
            }
        }

        private void DeleteAccount()
        {
            SelectedAccount = unitOfWork.AccountRepo.Ophalen(x => x.AccountID == Session.SelectedAccountId).SingleOrDefault();
            unitOfWork.AccountRepo.Verwijderen(SelectedAccount);
        }

        private void Balance()
        {
            BalanceViewModel balanceViewModel = new BalanceViewModel();
            View.BalanceView balanceView = new View.BalanceView();
            balanceView.DataContext = balanceViewModel;
            balanceView.Show();
        }

        private void Deposit()
        {
            DepositViewModel depositViewModel = new DepositViewModel();
            View.DepositView depositView = new View.DepositView();
            depositView.DataContext = depositViewModel;
            depositView.Show();
        }

        private void Withdraw()
        {
            WithdrawViewModel withdrawViewModel = new WithdrawViewModel();
            View.WithdrawView withdrawView = new View.WithdrawView();
            withdrawView.DataContext = withdrawViewModel;
            withdrawView.Show();
        }

        private void Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            View.LoginView loginView = new View.LoginView();
            loginView.DataContext = loginViewModel;
            loginView.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}