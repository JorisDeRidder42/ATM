using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ATM_JorisDeRidder_DAL.Data;
using ATM_JorisDeRidder_DAL.Data.UnitOfWork;
using ATM_JorisDeRidder_DAL.DomainModels;

namespace ATM_JorisDeRidder_WPF.ViewModel
{
    public class LoginViewModel : BasisViewModel
    {
        private IUnitOfWork unitOfWork = new UnitOfWork(new ATM_JorisDeRidderEntities());

        public Client Client { get; set; }

        public override string this[string columnName] => "";

        public string? foutmelding;

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Register": OpenRegisterPage(); break;
                case "Login": OpenLogin(); break;
            }
        }

        public void OpenLogin()
        {
            var clientName = unitOfWork.ClientRepo.Ophalen(c => c.ClientName == Client.ClientName).SingleOrDefault();
            var clientPassword = unitOfWork.ClientRepo.Ophalen(u => u.Password == Client.Password).SingleOrDefault();
            var clientIsAdmin = unitOfWork.ClientRepo.Ophalen(u => u.IsAdmin == Client.IsAdmin).FirstOrDefault();

            if (Client.ClientName == clientName.ClientName)
            {
                MessageBox.Show("Email or password doesn't match!");
            }
            else
            {
                MessageBox.Show("Email or password doesn't match!");
            }
        }

        private void OpenRegisterPage()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            View.RegisterView rview = new View.RegisterView();
            rview.DataContext = registerViewModel;
            rview.Show();
        }
    }
}