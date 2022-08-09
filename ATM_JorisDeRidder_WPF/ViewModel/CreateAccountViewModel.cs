using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
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
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Client> Clients { get; set; }
        public Account Account { get; set; }
        public Client Client { get; set; }
        public Account SelectedAccount { get; set; }

        public string AccountName { get; set; }
        public int AccountAmount { get; set; }

        public int AccountID { get; set; }

        public string? foutmelding { get; set; }
        public override string this[string columnName] => "";

        public CreateAccountViewModel(int? accountID = null)
        {
            if (AccountID != null)
            {
                //Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
                Account = unitOfWork.AccountRepo.Ophalen(x => x.AccountID == accountID, x => x.ClientAccounts.Select(y => y.Client)).SingleOrDefault();
            }
            //select enkelvoud
            //x => x.benaming  voor meervoud
            else
            {
                Account = new Account();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Back": Back(); break;
                case "Create": CreateNewAccount(); break;
            }
        }

        private void CreateNewAccount()
        {
            if (AccountID != null)
            {
                Account = new Account();
                if (Account.IsGeldig())
                {
                    unitOfWork.AccountRepo.Toevoegen(Account);
                    unitOfWork.Save();
                    RefreshData();
                    MessageBox.Show("Account added", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    OpenActionView();
                }
            }
        }

        private void RefreshData()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen());
        }

        private void Back()
        {
            LoginViewModel lViewModel = new LoginViewModel();
            View.LoginView lView = new View.LoginView();
            lView.DataContext = lViewModel;
            lView.Show();
        }

        public void OpenActionView()
        {
            ActionViewModel actionViewModel = new ActionViewModel();
            View.ActionView actionView = new View.ActionView();
            actionView.DataContext = actionViewModel;
            actionView.Show();
        }
    }
}