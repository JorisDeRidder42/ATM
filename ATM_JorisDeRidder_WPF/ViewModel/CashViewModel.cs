﻿using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using System;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class CashViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public override string this[string columnName] => "";

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "10": Withdraw10(); break;
                case "20": Withdraw20(); break;
                case "50": Withdraw50(); break;
                case "100": Withdraw100(); break;
                case "200": Withdraw200(); break;
                case "500": Withdraw500(); break;
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

        private void Withdraw500()
        {
            throw new NotImplementedException();
        }

        private void Withdraw200()
        {
            throw new NotImplementedException();
        }

        private void Withdraw100()
        {
            throw new NotImplementedException();
        }

        private void Withdraw50()
        {
            throw new NotImplementedException();
        }

        private void Withdraw20()
        {
            throw new NotImplementedException();
        }

        private void Withdraw10()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}