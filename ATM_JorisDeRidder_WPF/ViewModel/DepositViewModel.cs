﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class DepositViewModel : BasisViewModel
    {
        public override string this[string columnName] => throw new NotImplementedException();

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
            DepositViewModel depositViewModel = new DepositViewModel();
            View.DepositView depositView = new View.DepositView();
            depositView.DataContext = depositViewModel;
            depositView.Show();
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