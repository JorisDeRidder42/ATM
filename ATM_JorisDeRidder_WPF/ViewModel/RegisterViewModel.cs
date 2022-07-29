﻿using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class RegisterViewModel : BasisViewModel, IDisposable
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());

        public Client? Client { get; set; }
        public int? ClientID { get; set; }
        public string? ClientName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? BirthDate { get; set; }
        public bool? IsAdmin { get; set; }
        public string? ZipCode { get; set; }
        public Card? Card { get; private set; }
        public string? foutmelding { get; set; }

        public RegisterViewModel()
        {
            if (ClientID != null)
            {
                Client = unitOfWork.ClientRepo.Ophalen(c => c.ClientID).SingleOrDefault();
            }
            else
            {
                Client = new Client();
            }
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register": Register(); break;
                case "Back": GoBack(); break;
            }
        }

        public void Register()
        {
            if (ClientID == null)
            {
                Client.IsAdmin = false;
                Card = new Card();

                if (Password == ConfirmPassword)
                {
                    unitOfWork.ClientRepo.Toevoegen(Client);
                    unitOfWork.Save();

                    MessageBox.Show("Your account is created");
                    OpenLoginWindow();
                }
                else
                {
                    foutmelding = "Passwords are not identical";
                }
            }
            else
            {
                foutmelding = "Error! One or more fields aren't correct!";
            }
        }

        public void GoBack()
        {
            LoginViewModel viewModel = new LoginViewModel();
            View.LoginView view = new View.LoginView();
            view.DataContext = viewModel;
            view.Show();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

        public void OpenLoginWindow()
        {
            LoginViewModel lviewModel = new LoginViewModel();
            View.LoginView lview = new View.LoginView();
            lview.DataContext = lviewModel;
            lview.Show();
        }
    }
}