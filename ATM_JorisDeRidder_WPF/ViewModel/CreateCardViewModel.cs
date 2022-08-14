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
    public class CreateCardViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public ObservableCollection<Account> Accounts { get; set; }
        public ObservableCollection<Card> Cards { get; set; }
        public ObservableCollection<CardType> CardTypes { get; set; }

        private CardType _selectedCardType;

        public CardType SelectedCardType
        {
            get { return _selectedCardType; }
            set
            {
                _selectedCardType = value;
                NotifyPropertyChanged();
            }
        }

        public string AccountName { get; set; }

        public string CardName { get; set; }
        public string CardTypeName { get; set; }

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

        public CreateCardViewModel()
        {
            Cards = new ObservableCollection<Card>(unitOfWork.CardRepo.Ophalen(x => x.CardID == Session.SelectedCardId));
            CardTypes = new ObservableCollection<CardType>(unitOfWork.CardtypeRepo.Ophalen());
        }

        private void CreateNewAccount()
        {
            if (this.IsGeldig())
            {
                Card card = new Card()
                {
                    CardName = CardName,
                    CardTypeID = SelectedCardType.CardTypeID,
                };
                unitOfWork.CardRepo.Toevoegen(card);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    RefreshData();
                    GoToCardView();
                    MessageBox.Show("Card added", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
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

        public void GoToCardView()
        {
            CardViewModel cardViewModel = new CardViewModel();
            View.CardView cardView = new View.CardView();
            cardView.DataContext = cardViewModel;
            cardView.Show();
        }

        private void RefreshData()
        {
            Cards = new ObservableCollection<Card>(unitOfWork.CardRepo.Ophalen(x => x.CardID == Session.SelectedCardId));
            CardTypes = new ObservableCollection<CardType>(unitOfWork.CardtypeRepo.Ophalen());
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}