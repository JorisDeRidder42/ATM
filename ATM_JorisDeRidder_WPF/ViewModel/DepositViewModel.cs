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
    public class DepositViewModel : BasisViewModel, IDisposable
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

        public string Depo { get; set; }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Depo" && string.IsNullOrWhiteSpace(Depo))
                {
                    return "Number is required!" + Environment.NewLine;
                }
                if (columnName == "Depo" && !int.TryParse(Depo, out int depo))
                {
                    return "Please enter a number" + Environment.NewLine;
                }

                return "";
            }
        }

        public DepositViewModel()
        {
            Account = unitOfWork.AccountRepo.Ophalen(x => x.ClientID == Session.SelectedItemId).FirstOrDefault();
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
                case "Deposit": Deposit(); break;
            }
        }

        private void Deposit()
        {
            if (this.IsGeldig())
            {
                {
                    Account.AccountAmount += int.Parse(Depo);
                };

                unitOfWork.AccountRepo.Aanpassen(Account);
                unitOfWork.Save();
                RefreshData();
            }
            else
            {
                MessageBox.Show(Error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshData()
        {
            Account = unitOfWork.AccountRepo.Ophalen(x => x.ClientID == Session.SelectedItemId).SingleOrDefault();
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