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
    public class CardViewModel : BasisViewModel
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());

        private Card _selectedCard;

        public Card SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                _selectedCard = value;
                CardAccounts = new ObservableCollection<CardAccount>(unitOfWork.CardAccountRepo.Ophalen(x => x.CardID == SelectedCard.CardID));
                NotifyPropertyChanged();
            }
        }

        private Account _selectedAccount;

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                Session.SelectedAccountId = _selectedAccount.AccountID;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
            set { _cards = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<Card> _cards;
        private ObservableCollection<CardAccount> _cardacounts;

        public ObservableCollection<CardAccount> CardAccounts
        {
            get { return _cardacounts; }
            set
            {
                _cardacounts = value; NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Account> Accounts { get; set; }
        public int ClientID { get; set; }
        public string Foutmelding { get; set; }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public CardViewModel()
        {
            Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen(x => x.ClientID == Session.SelectedClientId));
            CardAccounts = new ObservableCollection<CardAccount>(unitOfWork.CardAccountRepo.Ophalen(x => x.AccountID == Session.SelectedAccountId));
            Cards = new ObservableCollection<Card>(unitOfWork.CardRepo.Ophalen());
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Card": OpenCreateCardWindow(); break;
                case "Bill": OpenCreateBillWindow(); break;
                case "Back": Back(); break;
                case "Go": GoToActionView(); break;
            }
        }

        private void GoToActionView()
        {
            if (SelectedCard != null && SelectedAccount != null)
            {
                Session.SelectedAccountId = SelectedAccount.AccountID;

                ActionViewModel actionViewModel = new ActionViewModel();
                View.ActionView actionView = new View.ActionView();
                actionView.DataContext = actionViewModel;
                actionView.Show();
            }
            else
            {
                MessageBox.Show("Please select a Card and or account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenCreateCardWindow()
        {
            CreateCardViewModel createCardViewModel = new CreateCardViewModel();
            View.CreateCardView createCardView = new View.CreateCardView();
            createCardView.DataContext = createCardViewModel;
            createCardView.Show();
        }

        private void OpenCreateBillWindow()
        {
            CreateAccountViewModel createAccountViewModel = new CreateAccountViewModel();
            View.CreateAccountView createAccountView = new View.CreateAccountView();
            createAccountView.DataContext = createAccountViewModel;
            createAccountView.Show();
        }

        private void Back()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            View.LoginView loginView = new View.LoginView();
            loginView.DataContext = loginViewModel;
            loginView.Show();
        }
    }
}