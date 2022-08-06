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

        public Account? Account { get; set; }
        public ICollection<Account>? Accounts { get; set; }

        public int AccountID { get; set; }
        public override string this[string columnName] => "";

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
            }
        }

        //private void RefreshData()
        //{
        //    Accounts = new ObservableCollection<Account>(unitOfWork.AccountRepo.Ophalen());
        //}

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