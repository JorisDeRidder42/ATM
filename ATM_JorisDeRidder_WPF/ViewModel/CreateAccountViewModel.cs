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
    public class CreateAccountViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public ObservableCollection<Account> Accounts { get; set; }

        public string AccountName { get; set; }

        public int ClientID { get; set; }
        public int TransactionID { get; set; }
        public int AccountAmount { get; set; }

        public string? Foutmelding { get; set; }
        public override string this[string columnName] => "";

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Back": Back(); break;
                case "Create": CreateNewAccount(); break;
            }
        }

        public CreateAccountViewModel()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen(x => x.ClientID == Session.SelectedClientId).Where(y => y.TransactionID == Session.SelectedTransactionId));
        }

        private void CreateNewAccount()
        {
            if (this.IsGeldig())
            {
                Account account = new Account()
                {
                    AccountName = AccountName,
                    AccountAmount = AccountAmount,
                    ClientID = Session.SelectedClientId,
                    TransactionID = 3,
                };
                unitOfWork.AccountRepo.Toevoegen(account);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                    MessageBox.Show("Bill added", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    OpenCardView();
                }
            }
        }

        private void Back()
        {
            LoginViewModel lViewModel = new LoginViewModel();
            View.LoginView lView = new View.LoginView();
            lView.DataContext = lViewModel;
            lView.Show();
        }

        public void OpenCardView()
        {
            CardViewModel cardViewModel = new CardViewModel();
            View.CardView cardView = new View.CardView();
            cardView.DataContext = cardViewModel;
            cardView.Show();
        }

        private void RefreshData()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen(y => y.ClientID == Session.SelectedClientId));
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}