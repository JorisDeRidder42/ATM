using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using ATM_JorisDeRidder_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class WithdrawViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        private Account _account;

        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                NotifyPropertyChanged();
            }
        }

        public string With { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "With" && string.IsNullOrWhiteSpace(With))
                {
                    return "Number is required!" + Environment.NewLine;
                }
                if (columnName == "With" && !int.TryParse(With, out int with))
                {
                    return "Please enter a number" + Environment.NewLine;
                }

                return "";
            }
        }

        public WithdrawViewModel()
        {
            Account = unitOfWork.AccountRepo.Ophalen(x => x.AccountID == Session.SelectedAccountId).SingleOrDefault();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Back": Back(); break;
                case "Withdraw": Withdraw(); break;
            }
        }

        private void Withdraw()
        {
            if (this.IsGeldig())
            {
                if (Account.AccountAmount > int.Parse(With))
                {
                    Account.AccountAmount -= int.Parse(With);
                    unitOfWork.AccountRepo.Aanpassen(Account);
                    unitOfWork.Save();
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Not enough money go work!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshData()
        {
            Account = unitOfWork.AccountRepo.Ophalen(x => x.AccountID == Session.SelectedAccountId).SingleOrDefault();
        }

        private void Back()
        {
            ActionViewModel actionViewModel = new ActionViewModel();
            View.ActionView actionView = new View.ActionView();
            actionView.DataContext = actionViewModel;
            actionView.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}