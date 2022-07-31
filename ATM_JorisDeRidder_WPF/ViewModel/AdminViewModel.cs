﻿using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class AdminViewModel : BasisViewModel
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());
        public ObservableCollection<Client> Clients { get; set; }
        public override string this[string columnName] => "";

        public AdminViewModel()
        {
            Clients = new ObservableCollection<Client>(unitOfWork.ClientRepo.Ophalen());
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
            }
        }

        private void Back()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lView = new View.LoginView();
            lView.DataContext = lviewModel;
            lView.Show();
        }
    }
}