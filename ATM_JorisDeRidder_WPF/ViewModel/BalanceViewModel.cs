using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class BalanceViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());

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

        private void Back()
        {
            ActionViewModel actionViewModel = new ActionViewModel();
            View.ActionView actionView = new View.ActionView();
            actionView.DataContext = actionViewModel;
            actionView.Show();
        }
    }
}